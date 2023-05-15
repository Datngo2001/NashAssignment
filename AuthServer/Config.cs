using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace AuthServer
{
    public class Config
    {
        private readonly string _customerSiteOrigin;
        private readonly string _adminSiteOrigin;

        public Config(string customerSiteOrigin, string adminSiteOrigin)
        {
            _customerSiteOrigin = customerSiteOrigin;
            _adminSiteOrigin = adminSiteOrigin;
        }

        public IEnumerable<IdentityResource> IdentityResources =>
           new IdentityResource[]
           {
                        new IdentityResources.OpenId(),
                        new IdentityResources.Profile(),
           };

        public IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("AssignmentAPI",new [] { JwtClaimTypes.Role }),
            };

        public IEnumerable<Client> Clients =>
        new Client[]
        {
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "CustomerSite",
                    ClientSecrets = { new Secret("49C1A7E1-0C79-4A89-A3D6-A37998FB86B0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { $"{_customerSiteOrigin}/signin-oidc" },
                    FrontChannelLogoutUri = $"{_customerSiteOrigin}/signout-oidc",
                    PostLogoutRedirectUris = { $"{_customerSiteOrigin}/signout-callback-oidc" },

                    AllowOfflineAccess = true,
                    AllowedScopes = {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "AssignmentAPI",
                        JwtClaimTypes.Role
                    }
                },
                new Client
                {
                    ClientId = "js",
                    ClientName = "JavaScript Client",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequireClientSecret = false,

                    RedirectUris =           { $"{_adminSiteOrigin}/callback" },
                    PostLogoutRedirectUris = { $"{_adminSiteOrigin}/" },
                    AllowedCorsOrigins =     { $"{_adminSiteOrigin}" },

                    AllowOfflineAccess = true,

                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "AssignmentAPI",
                        JwtClaimTypes.Role
                    }
                }
        };
    }
}