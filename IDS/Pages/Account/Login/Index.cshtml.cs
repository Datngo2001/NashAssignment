using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IDS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IDS.Pages.Account.Login
{
    public class Index : PageModel
    {
        [BindProperty]
        public LoginForm Form { get; set; } = new LoginForm();

        [BindProperty]
        public string ReturnUrl { get; set; } = "";

        private readonly ILogger<Index> _logger;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IIdentityServerInteractionService _interaction;

        public Index(ILogger<Index> logger,
                     SignInManager<AppUser> signInManager,
                     IIdentityServerInteractionService interaction)
        {
            _interaction = interaction;
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet([FromQuery(Name = "ReturnUrl")] string returnUrl)
        {
            ReturnUrl = returnUrl;
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!_interaction.IsValidReturnUrl(ReturnUrl))
                {
                    ModelState.AddModelError(string.Empty, "Invalid Return Url");
                };
                var context = await _interaction.GetAuthorizationContextAsync(ReturnUrl);
                var result = await _signInManager.PasswordSignInAsync(Form.UserName, Form.Password, Form.IsRemember, false);
                if (result.Succeeded)
                {
                    return Redirect(ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }

            return Page();
        }
    }
}