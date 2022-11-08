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
using API.Interfaces;
using AutoMapper;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "Admin")]
    public class UserController : _APIController
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, ApplicationDbContext dbContext, IUserRepository userRepository, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.dbContext = dbContext;
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpPost("create-role")]
        public async Task<ActionResult<AppRole>> CreateRole(string name)
        {
            var role = new AppRole() { Name = name };
            await roleManager.CreateAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        [HttpGet("get-roles")]
        public async Task<ActionResult<List<AppRole>>> GetRoles()
        {
            var roles = await dbContext.Roles.ToListAsync();
            return roles;
        }

        [HttpGet("get-user-in-role")]
        public async Task<ActionResult<List<AppUserDto>>> GetRoles(string name)
        {
            var users = await userManager.GetUsersInRoleAsync(name);
            var userDtos = new List<AppUserDto>();
            foreach (var user in users)
            {
                userDtos.Add(mapper.Map<AppUserDto>(user));
            }
            return userDtos;
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
            var user = await userManager.FindByIdAsync(id);
            await userManager.AddToRoleAsync(user, roleName);
            return Ok();
        }

        [HttpPost("search")]
        public async Task<ActionResult<PagingDto<AppUserDto>>> SearchCustomer([FromBody] UserSearchDto model)
        {
            return await userRepository.SearchCustomer(model.Query, model.Page, model.Limit);
        }

        [HttpGet("claims/{userId}")]
        public async Task<ActionResult<List<Claim>>> GetUserClaims([FromRoute] string userId)
        {
            return await userRepository.GetUserClaimsById(userId);
        }
    }
}