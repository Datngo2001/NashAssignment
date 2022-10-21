using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDetailDto?> GetProductById(int id);
        Task<List<ProductDto>> GetAllProduct(int page, int limit);
        Task<List<ProductDto>> SearchProduct(string query, int page, int limit);
        Task<List<ProductSearchHintDto>> SearchProductHint(string query, int limit);
        Task<double> AverageStar(int id);
    }
}