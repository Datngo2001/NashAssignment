using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel;
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

        [TempData]
        public string ProductId { get; set; }

        [BindProperty]
        public ProductDetailDto Product { get; set; } = new ProductDetailDto();

        [BindProperty]
        public PagingDto<RatingDto> RatingsWithPaging { get; set; } = new PagingDto<RatingDto>();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Product = await productService.GetProductByIdAsync(id);
            RatingsWithPaging = await ratingService.GetProductRating(id, 1);
            if (RatingsWithPaging.Items.Count() != 0)
            {
                ViewData["avg-star"] = await productService.GetProductStarAsync(id);
            }
            else
            {
                ViewData["avg-star"] = 0;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAddRatingAsync(AddRatingDto addRatingDto)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            if (accessToken == null || accessToken == "")
            {
                throw new Exception($"Missing access token");
            }

            await ratingService.AddRating(addRatingDto, accessToken);

            // return await OnGetAsync(addRatingDto.ProductId);
            return RedirectToPage(new { id = addRatingDto.ProductId });
        }
    }
}