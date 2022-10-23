using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("api1", "My API")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,
                    ClientSecrets = { new Secret("secret".Sha256()) },

                    RedirectUris =           { "http://localhost:21402/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:21402/" },
                    FrontChannelLogoutUri =    "http://localhost:21402/signout-oidc",

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,

                        "api1",
                    },
                }
            };
    }
}