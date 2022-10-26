using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    public class CategoryPageModel : PageModel
    {
        private readonly ICategoryService categoryService;

        public CategoryPageModel(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IActionResult> OnGet([FromQuery(Name = "id")] int id = 1, [FromQuery(Name = "p")] int page = 1)
        {
            var category = await categoryService.GetCategoryByIdAsync((int)id);
            var productsWithPaging = await categoryService.GetCategoryProductAsync((int)id, page);
            ViewData["category"] = category;
            ViewData["products"] = productsWithPaging.Items;
            ViewData["total-page"] = productsWithPaging.TotalPage;
            ViewData["page"] = productsWithPaging.Page;

            return Page();
        }
    }
}