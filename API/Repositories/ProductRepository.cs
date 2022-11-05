using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using API.Interfaces;
using CommonModel.Product;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using CommonModel;
using DataAccess.Entities;

namespace API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProduct(int page, int limit)
        {
            return await context.Products
                .OrderByDescending(p => p.UpdateDate)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProductDetailDto?> GetProductById(int id)
        {
            return await context.Products
                .Where(p => p.Id == id)
                .Include(p => p.Features)
                .Include(p => p.Categories)
                .ProjectTo<ProductDetailDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<PagingDto<ProductDto>> SearchProduct(string query, int page, int limit)
        {
            var queryable = context.Products.Where(p => p.Name.Contains(query)).OrderByDescending(p => p.UpdateDate);

            var products = await queryable
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            var count = await queryable.CountAsync();

            return new PagingDto<ProductDto>()
            {
                Page = page,
                Limit = limit,
                TotalPage = count / limit + 1,
                Items = products,
            };
        }

        public async Task<PagingDto<ProductDetailDto>> AdminSearchProduct(string query, int page, int limit)
        {
            var queryable = context.Products.AsNoTracking().Where(p => p.Name.Contains(query)).OrderByDescending(p => p.UpdateDate);

            var products = await queryable
                .Include(p => p.Features)
                .Include(p => p.Categories)
                .Include(p => p.Images)
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDetailDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            var count = await queryable.CountAsync();

            return new PagingDto<ProductDetailDto>()
            {
                Query = query,
                Page = page,
                Limit = limit,
                Count = count,
                TotalPage = count / limit + 1,
                Items = products,
            };
        }

        public async Task<List<ProductSearchHintDto>> SearchProductHint(string query, int limit)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))
                .OrderByDescending(p => p.UpdateDate)
                .Take(limit)
                .ProjectTo<ProductSearchHintDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<double> AverageStar(int id)
        {
            double result = 0;

            try
            {
                result = await context.Products.Where(p => p.Id == id).Select(p => p.Ratings.Average(r => r.Star)).FirstOrDefaultAsync();
            }
            catch (System.Exception)
            {
                result = 0;
            }

            return result;
        }

        public async Task<ProductDetailDto> CreateProduct(CreateProductDto createProductDto)
        {
            var product = mapper.Map<Product>(createProductDto);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return mapper.Map<ProductDetailDto>(product);
        }

        public async Task<ProductDetailDto> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var product = await context.Products.Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == updateProductDto.Id);

            if (product == null)
            {
                throw new Exception($"Can not find product with id: {updateProductDto.Id}");
            }

            context.Products.Update(product);

            product.Images = new List<Image>();
            mapper.Map(updateProductDto, product);

            product.UpdateDate = DateTime.Now;

            await context.SaveChangesAsync();

            return mapper.Map<ProductDetailDto>(product);
        }

        public async Task<ProductDetailDto> DeleteProduct(int id)
        {
            var product = await context.Products.FirstOrDefaultAsync(c => c.Id == id);
            if (product == null)
            {
                throw new Exception($"Can not find product with id: {id}");
            }

            context.Products.Remove(product);
            await context.SaveChangesAsync();

            return mapper.Map<ProductDetailDto>(product);
        }
    }
}