using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommonModel;
using CommonModel.Product;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class ProductController : _APIController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        [HttpPost("admin/search")]
        public async Task<ActionResult<PagingDto<ProductDetailDto>>> AdminSearchProducts([FromBody] ProductAdminSearchDto model)
        {
            return await productRepository.AdminSearchProduct(model.Query, model.Page, model.Limit);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        [HttpPost("create")]
        public async Task<ActionResult<ProductDetailDto>> CreateProducts([FromBody] CreateProductDto model)
        {
            return await productRepository.CreateProduct(model);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<List<ProductDto>>> GetAllProduct([FromQuery(Name = "p")] int page = 1)
        {
            return await productRepository.GetAllProduct(page, 10);
        }

        [HttpGet("search")]
        public async Task<ActionResult<PagingDto<ProductDto>>> SearchProduct([FromQuery(Name = "q")] string query = "", [FromQuery(Name = "p")] int page = 1)
        {
            return await productRepository.SearchProduct(query, page, 10);
        }

        [HttpGet("search-hint")]
        public async Task<ActionResult<List<ProductSearchHintDto>>> SearchProductHint([FromQuery(Name = "q")] string query = "")
        {
            return await productRepository.SearchProductHint(query, 10);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDetailDto>> GetProductById(int id)
        {
            var product = await productRepository.GetProductById(id);

            if (product == null)
            {
                return BadRequest();
            }

            return product;
        }

        [HttpGet("{id}/avg-star")]
        public async Task<ActionResult<double>> GetProductAvgStar(int id)
        {
            return await productRepository.AverageStar(id);
        }
    }
}