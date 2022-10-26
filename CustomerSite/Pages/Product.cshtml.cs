using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CustomerSite.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly IProductService productService;
        public ProductPageModel(IProductService productService)
        {
            this.productService = productService;
        }

        [BindProperty]
        public ProductDetailDto Product { get; set; } = new ProductDetailDto();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await productService.GetProductByIdAsync(id);
            var avgStar = await productService.GetProductStarAsync(id);
            ViewData["avg-star"] = avgStar;
            return Page();
        }

        public async Task<IActionResult> OnGetAddRatingAsync(int id)
        {
            ViewData["is-adding-rating"] = true;

            return await OnGetAsync(id);
        }
    }
}