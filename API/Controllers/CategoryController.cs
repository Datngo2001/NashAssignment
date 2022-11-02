using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using CommonModel;
using CommonModel.Category;
using CommonModel.Product;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto?>> getAll(int id)
        {
            var result = await categoryRepository.GetCategoryById(id);
            return result;
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<CategoryDto>>> getAll()
        {
            var result = await categoryRepository.GetAllCategories();
            return result;
        }

        [HttpGet("get-product-by-category")]
        public async Task<ActionResult<PagingDto<ProductDto>>> getProductByCategory([FromQuery(Name = "id")] int id, [FromQuery(Name = "page")] int page)
        {
            var result = await categoryRepository.GetProductByCategoryAsync(id, page, 10);
            return result;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        [HttpPost("admin/search")]
        public async Task<ActionResult<PagingDto<CategoryDto>>> AdminSearchProducts([FromBody] AdminSearchCategoryDto model)
        {
            return await categoryRepository.AdminSearchCategory(model.Query, model.Page, model.Limit);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        [HttpPost("create")]
        public async Task<ActionResult<CategoryDto>> CreateCategory([FromBody] CreateCategoryDto model)
        {
            return await categoryRepository.CreateCategory(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<CategoryDto>> DeleteCategory(int id)
        {
            return await categoryRepository.DeleteCategory(id);
        }
    }
}