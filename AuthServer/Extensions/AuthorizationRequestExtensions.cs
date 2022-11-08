using System;
using AuthServer.Models.Account;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc;

namespace AuthServer.Extensions
{
    public static class AuthorizationRequestExtensions
    {
        public static bool IsNativeClient(this AuthorizationRequest context)
        {
            return !context.RedirectUri.StartsWith("https", StringComparison.Ordinal)
               && !context.RedirectUri.StartsWith("http", StringComparison.Ordinal);
        }
    }
}
