using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CustomerSite.Interfaces;
using CustomerSite.Views.Shared.Components.SearchHint;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CustomerSite.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        public async Task<IActionResult> Index([FromQuery(Name = "q")] string query, [FromQuery(Name = "p")] int page = 1)
        {
            var productWithPaging = await searchService.SearchProduct(query, page);
            if (productWithPaging == null)
            {
                productWithPaging = new CommonModel.PagingDto<ProductDto>();
            }
            ViewData["query"] = query;
            return View(productWithPaging);
        }

        public async Task<IActionResult> GetSearchHint([FromQuery(Name = "q")] string query)
        {
            var hints = await searchService.LoadSearchHint(query);
            if (hints == null)
            {
                hints = new List<ProductSearchHintDto>();
            }
            return ViewComponent(nameof(SearchHint), new { hints = hints });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}