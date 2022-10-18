using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using CommonModel.Category;
using CommonModel.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    public class CategoryController : _APIController
    {

        private readonly ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<CategoryDto>>> getAll()
        {
            var result = await categoryRepository.GetAllCategories();
            return result;
        }

        [HttpGet("get-product-by-category")]
        public async Task<ActionResult<List<ProductDto>>> getProductByCategory([FromQuery(Name = "id")] int id, [FromQuery(Name = "page")] int page)
        {
            var result = await categoryRepository.GetProductByCategoryAsync(id, page, 10);
            return result;
        }
    }
}