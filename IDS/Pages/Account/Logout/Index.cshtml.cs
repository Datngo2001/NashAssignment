using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Extensions;
using IdentityServer4.Services;
using IDS.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace IDS.Pages.Account.Logout
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        private readonly IIdentityServerInteractionService _interaction;
        private readonly SignInManager<AppUser> _signInManager;

        public Index(ILogger<Index> logger, IIdentityServerInteractionService interaction, SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
            _interaction = interaction;
            _logger = logger;
        }

        public async Task<ActionResult> OnGet(string logoutId)
        {
            var logoutRequest = await _interaction.GetLogoutContextAsync(logoutId);

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
                            logoutId = await _interaction.CreateLogoutContextAsync();
                        }

                        string url = Url.Action("Logout", new { logoutId = logoutId });
                        return SignOut(new AuthenticationProperties { RedirectUri = url }, identityProvider);
                    }
                }
                else if (identityProvider == IdentityServer4.IdentityServerConstants.LocalIdentityProvider)
                {
                    await _signInManager.SignOutAsync();
                }
            }

            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}