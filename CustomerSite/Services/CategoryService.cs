using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;
using CommonModel.Category;
using CommonModel.Product;
using CommonModel;

namespace CustomerSite.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IHttpClientFactory clientFactory;

        public CategoryService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var httpClient = clientFactory.CreateClient();
            var data = await httpClient.GetApiAsync<List<CategoryDto>>("Category/get-all");

            if (data == null)
            {
                data = new List<CategoryDto>();
            }

            return data;
        }

        public async Task<CategoryDto?> GetCategoryByIdAsync(int id)
        {
            var httpClient = clientFactory.CreateClient();
            var data = await httpClient.GetApiAsync<CategoryDto>($"Category/{id}");

            return data;
        }

        public async Task<Paging<ProductDto>> GetCategoryProductAsync(int id, int page)
        {
            var httpClient = clientFactory.CreateClient();
            var data = await httpClient.GetApiAsync<Paging<ProductDto>>($"Category/get-product-by-category?id={id}&page={page}");

            if (data == null)
            {
                data = new Paging<ProductDto>();
            }

            return data;
        }
    }
}