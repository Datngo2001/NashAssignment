using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
using CommonModel.Category;
using CommonModel.Product;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<PagingDto<ProductDto>> GetProductByCategoryAsync(int id, int page, int limit);
        Task<CategoryDto?> GetCategoryById(int id);
        Task<PagingDto<CategoryDto>> AdminSearchCategory(string query, int page, int limit);
        Task<CategoryDto> CreateCategory(CreateCategoryDto createCategoryDto);
        Task<CategoryDto> DeleteCategory(int id);
    }
}