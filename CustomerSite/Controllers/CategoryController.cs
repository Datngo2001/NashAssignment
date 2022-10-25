using CustomerSite.Interfaces;
using CustomerSite.Models;
using CustomerSite.Pages.Shared.Components.ProductCardList;
using Microsoft.AspNetCore.Authorization;
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

        public async Task<IActionResult> Index([FromQuery(Name = "id")] int? id, [FromQuery(Name = "page")] int page = 1)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var category = await categoryService.GetCategoryByIdAsync((int)id);
            var productsWithPaging = await categoryService.GetCategoryProductAsync((int)id, page);
            ViewData["category"] = category;
            ViewData["products"] = productsWithPaging.Items;
            ViewData["total-page"] = productsWithPaging.TotalPage;
            ViewData["page"] = productsWithPaging.Page;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}