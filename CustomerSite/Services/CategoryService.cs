using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;
using CommonModel.Category;

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
            var data = await httpClient.GetApiAsync<List<CategoryDto>>("Category");

            if (data == null)
            {
                data = new List<CategoryDto>();
            }

            return data;
        }
    }
}