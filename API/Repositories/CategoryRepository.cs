using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CommonModel.Category;
using AutoMapper.QueryableExtensions;
using CommonModel.Product;

namespace API.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApiDbContext dbContext;
        private readonly IMapper mapper;

        public CategoryRepository(ApiDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
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

        public async Task<List<ProductDto>> GetProductByCategoryAsync(int id, int page, int limit)
        {
            var products = await dbContext.Products
                .Where(p => p.Categories.Any(c => c.Id == id))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            if (products == null)
            {
                return new List<ProductDto>();
            }

            return products;
        }
    }
}