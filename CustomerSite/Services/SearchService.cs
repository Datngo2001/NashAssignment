using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;
using CommonModel;

namespace CustomerSite.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory clientFactory;
        public SearchService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<ProductSearchHintDto>> LoadSearchHint(string query)
        {
            var httpClient = clientFactory.CreateClient();
            var hints = await httpClient.GetApiAsync<List<ProductSearchHintDto>>($"Product/search-hint?q={query}");

            if (hints == null)
            {
                throw new Exception($"Can not get hint with key word \"{query}\"");
            }

            return hints;
        }

        public async Task<PagingDto<ProductDto>> SearchProduct(string query, int page)
        {
            var httpClient = clientFactory.CreateClient();
            var productWithPaging = await httpClient.GetApiAsync<PagingDto<ProductDto>>($"Product/search?q={query}&p={page}");

            if (productWithPaging == null)
            {
                throw new Exception($"Can not search with key word \"{query}\"");
            }

            return productWithPaging;
        }
    }
}