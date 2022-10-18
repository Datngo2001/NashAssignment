using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;
using CommonModel.Product;

namespace CustomerSite.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<List<ProductDto>> GetCategoryProductAsync(int id, int page);
    }
}