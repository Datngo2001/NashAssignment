using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;
using IDS.Interfaces;
using IDS.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace IDS.Services
{
    public class AppTokenService : IAppTokenService
    {
        private GoogleConfig _googleConfig = new GoogleConfig();
        private readonly IConfiguration _configuration;

        public AppTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
            _configuration.GetSection("GoogleConfig").Bind(_googleConfig);
        }

        public async Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string token)
        {
            GoogleJsonWebSignature.Payload payload;

            try
            {
                payload = await GoogleJsonWebSignature.ValidateAsync(token);
            }
            catch (InvalidJwtException ex)
            {
                throw ex;
            }

            if (!payload.Audience.Equals(_googleConfig.ClientId))
                throw new Exception($"Invalid Token Audience: {payload.Audience}");
            if (!payload.Issuer.Equals("accounts.google.com") && !payload.Issuer.Equals("https://accounts.google.com"))
                throw new Exception($"Invalid Token Issuer: {payload.Issuer}");
            if (payload.ExpirationTimeSeconds == null)
                throw new Exception("Invalid Token Expiration Time");
            else
            {
                DateTime now = DateTime.Now.ToUniversalTime();
                DateTime expiration = DateTimeOffset.FromUnixTimeSeconds((long)payload.ExpirationTimeSeconds).DateTime;
                if (now > expiration)
                {
                    throw new Exception("Token expired");
                }
            }

            return payload;
        }
    }
}