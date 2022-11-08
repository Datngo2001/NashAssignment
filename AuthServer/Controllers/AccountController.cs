using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
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

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            var vm = new RegisterViewModel()
            {
                ReturnUrl = returnUrl
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string button)
        {
            var context = await interaction.GetAuthorizationContextAsync(model.ReturnUrl);

            if (ModelState.IsValid)
            {
                var userByName = await userManager.FindByNameAsync(model.UserName);
                var userByEmail = await userManager.FindByNameAsync(model.Email);
                if (userByName == null && userByEmail == null)
                {
                    var newUser = new AppUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        EmailConfirmed = false,
                    };

                    var result = await userManager.CreateAsync(newUser, model.Password);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                    }

                    result = await userManager.AddClaimsAsync(newUser, new Claim[]{
                        new Claim(JwtClaimTypes.Name, model.FirstName + model.LastName),
                        new Claim(JwtClaimTypes.GivenName, model.LastName),
                        new Claim(JwtClaimTypes.FamilyName, model.FirstName),
                    });
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                    }

                    result = await userManager.AddToRoleAsync(newUser, "customer");
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError(string.Empty, result.Errors.First().Description);
                    }

                    // signin user after created
                    await signInManager.SignInAsync(newUser, isPersistent: true);

                    if (context != null)
                    {
                        if (context.IsNativeClient())
                        {
                            return this.LoadingPage("Redirect", model.ReturnUrl);
                        }

                        return Redirect(model.ReturnUrl);
                    }

                    // request for a local page
                    if (Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else if (string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect("~/");
                    }
                    else
                    {
                        throw new Exception("invalid return URL");
                    }
                }

                ModelState.AddModelError(string.Empty, "Username or email existed");
            }

            return View(model);
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