using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using CommonModel.Category;

namespace API.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<CategoryDto>> GetAllCategories();
    }
}