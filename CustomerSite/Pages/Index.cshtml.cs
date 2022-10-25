using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CustomerSite.Pages.Shared.Components.ProductCardList;

namespace CustomerSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IIdentityService identityService;

        public IndexModel(ICategoryService categoryService, IProductService productService, IIdentityService identityService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.identityService = identityService;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["categories"] = await categoryService.GetAllAsync();
            ViewData["products"] = await productService.GetAllAsync(page: 1);
            return Page();
        }

        public async Task<ViewComponentResult> OnGetMoreProductAsync([FromQuery(Name = "p")] int page)
        {
            var products = await productService.GetAllAsync(page);
            return ViewComponent(nameof(ProductCardList), products);
        }
    }
}