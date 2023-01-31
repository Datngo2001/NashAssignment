using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDS.Pages.Account.Google
{
    public class GoogleResponse
    {
        public string Token { get; set; } = "";
        public string ReturnUrl { get; set; } = "";
    }
}