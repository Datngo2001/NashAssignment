using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using CommonModel.Product;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApiDbContext context;
        private readonly IMapper mapper;

        public ProductRepository(ApiDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllProduct(int page, int limit)
        {
            return await context.Products
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
                .Include(p => p.Rattings)
                .ProjectTo<ProductDetailDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<List<ProductDto>> SearchProduct(string query, int page, int limit)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ProductSearchHintDto>> SearchProductHint(string query, int limit)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))
                .Take(limit)
                .ProjectTo<ProductSearchHintDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}