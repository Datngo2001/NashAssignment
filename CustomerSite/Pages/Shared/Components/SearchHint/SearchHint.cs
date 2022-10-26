using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonModel.Product;
using Microsoft.AspNetCore.Mvc;

namespace CustomerSite.Pages.Shared.Components.SearchHint
{
    [ViewComponent]
    public class SearchHint : ViewComponent
    {
        public IViewComponentResult Invoke(List<ProductSearchHintDto> hints)
        {
            var searchLinkParam = new List<Dictionary<string, string>>();
            foreach (var hint in hints)
            {
                searchLinkParam.Add(new Dictionary<string, string> { { "q", hint.hint } });
            }
            return View(searchLinkParam);
        }
    }
}