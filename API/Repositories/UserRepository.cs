using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Interfaces;
using AutoMapper;
using CommonModel.User;
using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using CommonModel;
using System.Security.Claims;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public UserRepository(ApplicationDbContext context, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<List<Claim>> GetUserClaimsById(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var claims = await userManager.GetClaimsAsync(user);
            return claims.ToList();
        }

        public async Task<PagingDto<AppUserDto>> SearchCustomer(string query, int page, int limit)
        {
            var customerRole = await roleManager.FindByNameAsync("customer");

            var linqQuery =
                from u in context.Users
                join ur in context.UserRoles on u.Id equals ur.UserId
                join r in context.Roles on ur.RoleId equals r.Id
                where (r.Id == customerRole.Id && u.UserName.Contains(query))
                select u;

            var customers = await linqQuery
                .Skip((page - 1) * limit)
                .Take(limit)
                .ProjectTo<AppUserDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            var count = await linqQuery.CountAsync();


            if (customers == null)
            {
                return new PagingDto<AppUserDto>();
            }

            return new PagingDto<AppUserDto>()
            {
                Query = query,
                Page = page,
                Limit = limit,
                Count = count,
                TotalPage = count / limit + 1,
                Items = customers,
            };
        }
    }
}