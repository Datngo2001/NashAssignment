using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CommonModel.User
{
    public class AppUserDto
    {
        public string Id { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Email { get; set; } = "";
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; } = "";
        public bool PhoneNumberConfirmed { get; set; }
    }
}