using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CustomerSite.Extensions;
using CustomerSite.Interfaces;

namespace CustomerSite.Services
{
    public class ProductService : IProductService
    {
        private readonly IHttpClientFactory clientFactory;

        public ProductService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<ProductDto>> GetAllAsync(int page = 1)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<List<ProductDto>>($"Product/get-all?p={page}");

            if (result == null)
            {
                result = new List<ProductDto>();
            }

            return result;
        }

        public async Task<ProductDetailDto> GetProductByIdAsync(int id)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<ProductDetailDto>($"Product/{id}");

            if (result == null)
            {
                throw new Exception("Can not get product");
            }

            return result;
        }

        public async Task<ProductDto> GetProductBriefByIdAsync(int id)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<ProductDto>($"Product/{id}/brief");

            if (result == null)
            {
                throw new Exception("Can not get product");
            }

            return result;
        }

        public async Task<double> GetProductStarAsync(int id)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiNumberAsync($"Product/{id}/avg-star");

            return result;
        }

        public async Task<List<ProductDto>> SearchAsync(string query = "", int page = 1)
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<List<ProductDto>>($"Product/search?q={query}&p={page}");

            if (result == null)
            {
                result = new List<ProductDto>();
            }

            return result;
        }

        public async Task<List<ProductSearchHintDto>> SearchHintAsync(string query = "")
        {
            var httpClient = clientFactory.CreateClient();

            var result = await httpClient.GetApiAsync<List<ProductSearchHintDto>>($"Product/search-hint?q={query}");

            if (result == null)
            {
                result = new List<ProductSearchHintDto>();
            }

            return result;
        }
    }
}