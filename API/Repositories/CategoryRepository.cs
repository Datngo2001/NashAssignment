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
    }
}