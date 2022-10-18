using CustomerSite.Interfaces;
using CustomerSite.Models;
using CustomerSite.Views.Shared.Components.ProductCardList;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public HomeController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["categories"] = await categoryService.GetAllAsync();
            ViewData["products"] = await productService.GetAllAsync(page: 1);
            return View();
        }

        public async Task<IActionResult> MoreProduct([FromQuery(Name = "p")] int page)
        {
            var products = await productService.GetAllAsync(page);
            return ViewComponent(nameof(ProductCardList), products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}