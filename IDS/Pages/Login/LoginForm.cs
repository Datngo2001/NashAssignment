using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDS.Pages.Login
{
    public class LoginForm
    {
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";
        public bool IsRemember { get; set; }
    }
}