using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Entities;
using CommonModel;
using CommonModel.User;
using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
    public class UserController : _APIController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly ApplicationDbContext dbContext;

        public UserController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
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
        public async Task<ActionResult<List<AppRole>>> GetRoles()
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

        // [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
        // [HttpPost("admin/search")]
        // public async Task<ActionResult<PagingDto<ApplicationUser>>> SearchCustomer([FromBody] UserSearchDto model)
        // {
        //     // return await productRepository.AdminSearchProduct(model.Query, model.Page, model.Limit);
        //     var customers = await dbContext.Users.Where(u=>u.UserRoles.Where(ur=>ur.Role.))

        //     dbContext.UserRoles.Where(ur=>ur.RoleId == asdasd)
        // }
    }
}