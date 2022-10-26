using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Category;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Pages.Shared.Components.CategoryCard
{
    [ViewComponent]
    public class CategoryCard : ViewComponent
    {
        public IViewComponentResult Invoke(CategoryDto category)
        {
            return View(category);
        }
    }
}