using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CommonModel.Category;
using AutoMapper.QueryableExtensions;
using CommonModel.Product;
using CommonModel;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryRepository(ApplicationDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<PagingDto<CategoryDto>> AdminSearchCategory(string query, int page, int limit)
        {
            var queryable = dbContext.Categories.Where(p => p.Name.Contains(query));

            var categories = await queryable
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            var count = await queryable.CountAsync();

            return new PagingDto<CategoryDto>()
            {
                Query = query,
                Page = page,
                Limit = limit,
                Count = count,
                TotalPage = count / limit + 1,
                Items = categories,
            };
        }

        public async Task<CategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var category = mapper.Map<Category>(createCategoryDto);
            dbContext.Categories.Add(category);
            await dbContext.SaveChangesAsync();

            return mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> DeleteCategory(int id)
        {
            var category = await dbContext.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null)
            {
                throw new Exception($"Can not find category with id: {id}");
            }

            dbContext.Categories.Remove(category);
            await dbContext.SaveChangesAsync();

            return mapper.Map<CategoryDto>(category);
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            return await dbContext.Categories
                .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<CategoryDto?> GetCategoryById(int id)
        {
            return await dbContext.Categories
                .Where(c => c.Id == id)
                .ProjectTo<CategoryDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        public async Task<PagingDto<ProductDto>> GetProductByCategoryAsync(int id, int page, int limit)
        {
            var query = dbContext.Products.Where(p => p.Categories.Any(c => c.Id == id));

            var products = await query.Skip((page - 1) * limit).Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            var count = await query.CountAsync();

            if (products == null)
            {
                return new PagingDto<ProductDto>();
            }

            return new PagingDto<ProductDto>()
            {
                Page = page,
                Limit = limit,
                TotalPage = count / limit + 1,
                Items = products,
            };
        }
    }
}