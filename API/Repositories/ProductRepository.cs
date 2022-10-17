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

        public async Task<List<ProductDto>> SearchProduct(string query, int page, int limit)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<ProductDto>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<List<ProductSearchHint>> SearchProductHint(string query, int limit)
        {
            return await context.Products
                .Where(p => p.Name.Contains(query))
                .Take(limit)
                .ProjectTo<ProductSearchHint>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}