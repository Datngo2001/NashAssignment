using DataAccess.Entities;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using DataAccess;

namespace AuthServer
{
    public class SeedData
    {
        public static void Seed(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddIdentity<AppUser, AppRole>()
              .AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            var serviceProvider = services.BuildServiceProvider();

            using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var ctx = scope.ServiceProvider.GetService<ApplicationDbContext>();
                ctx.Database.Migrate();

                EnsureUsers(scope);
            }
        }

        private static void EnsureUsers(IServiceScope scope)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>();

            var adminRole = roleMgr.FindByNameAsync("admin").Result;
            if (adminRole == null)
            {
                var result = roleMgr.CreateAsync(new AppRole() { Name = "admin" }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }
                Console.WriteLine("admin role created");
            }

            var admin = userMgr.FindByNameAsync("admin").Result;
            if (admin == null)
            {
                admin = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@email.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(admin, "Admin@123").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddToRoleAsync(admin, "admin").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, "admin admin"),
                    new Claim(JwtClaimTypes.GivenName, "admin"),
                    new Claim(JwtClaimTypes.FamilyName, "admin"),
                    new Claim(JwtClaimTypes.WebSite, "http://admin.com"),
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Console.WriteLine("admin created");
            }
            else
            {
                Console.WriteLine("admin already exists");
            }

            var alice = userMgr.FindByNameAsync("alice").Result;
            if (alice == null)
            {
                alice = new AppUser
                {
                    UserName = "alice",
                    Email = "AliceSmith@email.com",
                    EmailConfirmed = true,
                };
                var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(alice, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, "Alice Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Alice"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Console.WriteLine("alice created");
            }
            else
            {
                Console.WriteLine("alice already exists");
            }

            var bob = userMgr.FindByNameAsync("bob").Result;
            if (bob == null)
            {
                bob = new AppUser
                {
                    UserName = "bob",
                    Email = "BobSmith@email.com",
                    EmailConfirmed = true
                };
                var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userMgr.AddClaimsAsync(bob, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim("location", "somewhere")
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Console.WriteLine("bob created");
            }
            else
            {
                Console.WriteLine("bob already exists");
            }
        }
    }
}
