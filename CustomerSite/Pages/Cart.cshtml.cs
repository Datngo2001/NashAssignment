using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        public ActionResult OnGet()
        {
            return Page();  
        }
    }
}
