using IdentityServer4.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Json;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Test;

namespace IDS
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
          new[]
          {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource
            {
              Name = "role",
              UserClaims = new List<string> {"role"}
            }
          };

        public static IEnumerable<ApiScope> ApiScopes =>
          new[]
          {
            new ApiScope("API.read"),
            new ApiScope("API.write"),
          };
        public static IEnumerable<ApiResource> ApiResources => new[]
        {
          new ApiResource("API")
          {
            Scopes = new List<string> {"API.read", "API.write"},
            ApiSecrets = new List<Secret> {new Secret("ScopeSecret".Sha256())},
            UserClaims = new List<string> {"role"}
          }
        };

        public static IEnumerable<Client> Clients =>
          new[]
        {
          // m2m client credentials flow client
          new Client
          {
            ClientId = "m2m.client",
            ClientName = "Client Credentials Client",

            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

            AllowedScopes = {"API.read", "API.write"}
          },

          // interactive client using code flow + pkce
          new Client
          {
            ClientId = "interactive",
            ClientSecrets = {new Secret("SuperSecretPassword".Sha256())},

            AllowedGrantTypes = GrantTypes.Code,

            RedirectUris = {"https://localhost:5002/signin-oidc"},
            FrontChannelLogoutUri = "https://localhost:5002/signout-oidc",
            PostLogoutRedirectUris = {"https://localhost:5002/signout-callback-oidc"},

            AllowOfflineAccess = true,
            AllowedScopes = {"openid", "profile", "API.read", "API.write"},
            RequirePkce = true,
            RequireConsent = false,
            AllowPlainTextPkce = false
          },
          new Client
          {
            ClientId = "js",
            ClientName = "JavaScript Client",
            AllowedGrantTypes = GrantTypes.Code,
            RequireClientSecret = false,

            RedirectUris =           { "http://localhost:3000/callback" },
            PostLogoutRedirectUris = { "http://localhost:3000/" },
            AllowedCorsOrigins =     { "http://localhost:3000" },

            AllowedScopes = {"openid", "profile", "API.read", "API.write", "role"},
          }
        };
    }
}