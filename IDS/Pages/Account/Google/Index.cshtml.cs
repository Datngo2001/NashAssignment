using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IDS.Pages.Account.Google
{
    public class Index : PageModel
    {
        [BindProperty]
        public string Token { get; set; } = "";

        [BindProperty]
        public string ReturnUrl { get; set; } = "";

        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public PageResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public PageResult OnPost()
        {
            Console.WriteLine("POST: " + Token);
            Console.WriteLine("POST: " + ReturnUrl);
            return Page();
        }
    }
}