using CustomerSite.Interfaces;
using CustomerSite.Models;
using CustomerSite.Views.Shared.Components.ProductCardList;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CustomerSite.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> Index([FromQuery(Name = "id")] int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = await categoryService.GetCategoryByIdAsync((int)id);
            var products = await categoryService.GetCategoryProductAsync((int)id, 1);
            ViewData["category"] = category;
            ViewData["products"] = products;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}