using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CommonModel;
using CommonModel.Product;
using Microsoft.AspNetCore.Mvc;
using CustomerSite.Pages.Shared.Components.SearchHint;

namespace CustomerSite.Pages
{
    public class SearchPageModel : PageModel
    {
        private readonly ISearchService searchService;

        public SearchPageModel(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [BindProperty]
        public PagingDto<ProductDto> ProductsWithPaging { get; set; } = new PagingDto<ProductDto>();

        public async Task<IActionResult> OnGetAsync([FromQuery(Name = "q")] string query, [FromQuery(Name = "p")] int page = 1)
        {
            ProductsWithPaging = await searchService.SearchProduct(query, page);
            if (ProductsWithPaging == null)
            {
                ProductsWithPaging = new PagingDto<ProductDto>();
            }
            ViewData["query"] = query;
            return Page();
        }

        public async Task<IActionResult> OnGetSearchHintAsync([FromQuery(Name = "q")] string query)
        {
            var hints = await searchService.LoadSearchHint(query);
            if (hints == null)
            {
                hints = new List<ProductSearchHintDto>();
            }
            return ViewComponent(nameof(SearchHint), new { hints = hints });
        }

    }
}