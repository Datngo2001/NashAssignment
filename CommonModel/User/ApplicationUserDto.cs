using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CommonModel.User
{
    public class ApplicationUserDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public List<Claim> Claims { get; set; } = new List<Claim>();
    }
}