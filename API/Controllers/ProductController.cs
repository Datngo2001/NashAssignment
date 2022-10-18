using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CommonModel.Product;

namespace API.Controllers
{
    public class ProductController : _APIController
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet("get-all")]
        public async Task<List<ProductDto>> GetAllProduct([FromQuery(Name = "p")] int page = 1)
        {
            return await productRepository.GetAllProduct(page, 10);
        }

        [HttpGet("search")]
        public async Task<List<ProductDto>> SearchProduct([FromQuery(Name = "q")] string query = "", [FromQuery(Name = "p")] int page = 1)
        {
            return await productRepository.SearchProduct(query, page, 10);
        }

        [HttpGet("search-hint")]
        public async Task<List<ProductSearchHintDto>> SearchProductHint([FromQuery(Name = "q")] string query = "")
        {
            return await productRepository.SearchProductHint(query, 10);
        }
    }
}