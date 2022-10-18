using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommonModel.Product;

namespace CustomerSite.Views.Shared.Components.ProductCard
{
    [ViewComponent]
    public class ProductCard : ViewComponent
    {
        public IViewComponentResult Invoke(ProductDto product)
        {
            return View(product);
        }
    }
}