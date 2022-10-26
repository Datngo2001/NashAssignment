using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommonModel.Product;

namespace CustomerSite.Pages.Shared.Components.ProductCardList
{
    [ViewComponent]
    public class ProductCardList : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductDto> products)
        {
            return View(products);
        }
    }
}