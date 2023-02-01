using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Services;
using IDS.Entities;
using IDS.Interfaces;
using Microsoft.AspNetCore.Identity;
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
        private readonly IAppTokenService _tokenService;
        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public Index(
            ILogger<Index> logger,
            IAppTokenService tokenService,
            IIdentityServerInteractionService interaction,
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager)
        {
            _interaction = interaction;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _tokenService = tokenService;
        }

        public PageResult OnGet()
        {
            return Page();
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!_interaction.IsValidReturnUrl(ReturnUrl))
                {
                    throw new Exception("Invalid Return Url");
                };

                var context = await _interaction.GetAuthorizationContextAsync(ReturnUrl);

                try
                {
                    var payload = await _tokenService.ValidateGoogleToken(Token);
                    var user = await _userManager.FindByEmailAsync(payload.Email);
                    if (user == null)
                    {
                        user = new AppUser()
                        {
                            Email = payload.Email,
                            EmailConfirmed = payload.EmailVerified,
                            UserName = payload.Email,
                            Picture = payload.Picture,
                            FirstName = payload.FamilyName,
                            LastName = payload.GivenName,
                        };
                        var identityResult = await _userManager.CreateAsync(user);
                        if (identityResult.Succeeded == false)
                        {
                            throw new Exception(identityResult.Errors.First().Description);
                        }
                    }
                    await _signInManager.SignInAsync(user, true);

                    return Redirect(ReturnUrl);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            return Page();
        }
    }
}