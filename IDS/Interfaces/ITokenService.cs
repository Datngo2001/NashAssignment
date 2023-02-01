using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth;

namespace IDS.Interfaces
{
    public interface IAppTokenService
    {
        Task<GoogleJsonWebSignature.Payload> ValidateGoogleToken(string token);
    }
}