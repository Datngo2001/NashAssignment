using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;

namespace CustomerSite.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync(int page = 1);
        Task<List<ProductDto>> SearchAsync(string query = "", int page = 1);
        Task<List<ProductSearchHintDto>> SearchHintAsync(string query = "");
    }
}