using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using CommonModel.Category;
using CommonModel.Product;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
        Task<List<ProductDto>> GetProductByCategoryAsync(int id, int page, int limit);
    }
}