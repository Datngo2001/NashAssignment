using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerSite.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Pages.Shared.Components.RatingStars
{
    [ViewComponent]
    public class RatingStars : ViewComponent
    {
        public IViewComponentResult Invoke(RatingStarsViewModel model)
        {
            return View(model);
        }
    }
}