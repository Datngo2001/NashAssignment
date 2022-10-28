using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using CommonModel.Rating;
using CustomerSite.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    public class ProductPageModel : PageModel
    {
        private readonly IProductService productService;
        private readonly IRatingService ratingService;
        public ProductPageModel(IProductService productService, IRatingService ratingService)
        {
            this.ratingService = ratingService;
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

        public async Task<IActionResult> OnPostAddRatingAsync()
        {
            var addRatingDto = new AddRatingDto()
            {
                ProductId = Convert.ToInt32(Request.Form["ProductId"]),
                Message = Request.Form["Message"],
                Star = Convert.ToInt32(Request.Form["Star"])
            };

            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (accessToken == null)
            {
                throw new Exception($"Missing access token");
            }

            await ratingService.AddRating(addRatingDto, accessToken);

            // return await OnGetAsync(addRatingDto.ProductId);
            return RedirectToPage(new { id = addRatingDto.ProductId });
        }
    }
}