using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Extensions;
using AuthServer.Models.Account;
using DataAccess.Entities;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuthServer.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IIdentityServerInteractionService interaction;
        private readonly IClientStore clientStore;
        private readonly IAuthenticationSchemeProvider schemeProvider;

        public AccountController(
            ILogger<AccountController> logger,
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            IIdentityServerInteractionService interaction,
            IClientStore clientStore,
            IAuthenticationSchemeProvider schemeProvider
           )
        {
            _logger = logger;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.interaction = interaction;
            this.clientStore = clientStore;
            this.schemeProvider = schemeProvider;
        }

        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var context = await interaction.GetAuthorizationContextAsync(returnUrl);
            var schemes = await schemeProvider.GetAllSchemesAsync();

            var providers = await getProvider();

            var vm = new LoginViewModel
            {
                ReturnUrl = returnUrl,
                Username = context?.LoginHint ?? "",
                ExternalProviders = providers.ToArray()
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputModel model, string button)
        {
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, true, true);
                if (result.Succeeded)
                {
                    return Redirect(model.ReturnUrl);
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password");
            }

            var providers = await getProvider();
            var vm = new LoginViewModel
            {
                ReturnUrl = model.ReturnUrl,
                Username = context?.LoginHint ?? "",
                ExternalProviders = providers.ToArray()
            };

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            var logoutRequest = await interaction.GetLogoutContextAsync(logoutId);

            if (User?.Identity?.IsAuthenticated == true)
            {
                var identityProvider = User.FindFirst(JwtClaimTypes.IdentityProvider)?.Value;
                if (identityProvider != null && identityProvider != IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    var providerSupportsSignout = await HttpContext.GetSchemeSupportsSignOutAsync(identityProvider);
                    if (providerSupportsSignout)
                    {
                        if (logoutId == null)
                        {
                            logoutId = await interaction.CreateLogoutContextAsync();
                        }

                        string url = Url.Action("Logout", new { logoutId = logoutId });
                        return SignOut(new AuthenticationProperties { RedirectUri = url }, identityProvider);
                    }
                }
                else if (identityProvider == IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    await signInManager.SignOutAsync();
                }
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        private async Task<List<ExternalProvider>> getProvider()
        {
            var schemes = await schemeProvider.GetAllSchemesAsync();
            var providers = schemes
                 .Where(x => x.DisplayName != null)
                 .Select(x => new ExternalProvider
                 {
                     DisplayName = x.DisplayName ?? x.Name,
                     AuthenticationScheme = x.Name
                 }).ToList();
            if (providers == null)
            {
                return new List<ExternalProvider>();
            }
            return providers;
        }
    }
}