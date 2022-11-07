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
        public string Email { get; set; } = "";
        public string UserName { get; set; } = "";
        public List<AppRoleDto> Roles { get; set; } = new List<AppRoleDto>();
    }
}