using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.Product;

namespace API.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDetailDto?> GetProductById(int id);
        Task<List<ProductDto>> GetAllProduct(int page, int limit);
        Task<PagingDto<ProductDto>> SearchProduct(string query, int page, int limit);
        Task<List<ProductSearchHintDto>> SearchProductHint(string query, int limit);
        Task<double> AverageStar(int id);
        Task<PagingDto<ProductDetailDto>> AdminSearchProduct(string query, int page, int limit);
        Task<ProductDetailDto> CreateProduct(CreateProductDto createProductDto);
        Task<ProductDetailDto> UpdateProduct(UpdateProductDto updateProductDto);
        Task<ProductDetailDto> DeleteProduct(int id);
    }
}