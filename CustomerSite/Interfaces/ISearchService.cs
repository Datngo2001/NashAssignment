using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.Product;

namespace CustomerSite.Interfaces
{
    public interface ISearchService
    {
        Task<List<ProductSearchHintDto>?> LoadSearchHint(string query);
        Task<PagingDto<ProductDto>?> SearchProduct(string query, int page);
    }
}