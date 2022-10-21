using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CustomerSite.Interfaces;
using CustomerSite.Extensions;

namespace CustomerSite.Services
{
    public class SearchService : ISearchService
    {
        private readonly IHttpClientFactory clientFactory;
        public SearchService(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }

        public async Task<List<ProductSearchHintDto>?> LoadSearchHint(string query)
        {
            var httpClient = clientFactory.CreateClient();
            var hints = await httpClient.GetApiAsync<List<ProductSearchHintDto>>($"Product/search-hint?q={query}");
            return hints;
        }
    }
}