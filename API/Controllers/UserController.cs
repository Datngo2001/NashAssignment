using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
    public class UserController : _APIController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public UserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
        }

        [HttpPost("create-role")]
        public async Task<ActionResult<IdentityRole>> CreateRole(string name)
        {
            var role = new IdentityRole() { Name = name };
            await roleManager.CreateAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        [HttpGet("get-role")]
        public async Task<ActionResult<List<IdentityRole>>> GetRoles()
        {
            var roles = await dbContext.Roles.ToListAsync();
            return roles;
        }

        [HttpDelete("delete-role")]
        public async Task<ActionResult> DeleteRole(string name)
        {
            var role = await roleManager.FindByNameAsync(name);
            await roleManager.DeleteAsync(role);
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("add-user-to-role")]
        public async Task<ActionResult> AddUserToRole(string id, string roleName)
        {
            var roles = await dbContext.Roles.ToListAsync();
            var user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, roleName);
            return Ok();
        }

    }
}