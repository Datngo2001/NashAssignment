using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CustomerSite.Pages
{
    [Authorize]
    public class SigninPageModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/");
            // return Page();
        }
    }
}