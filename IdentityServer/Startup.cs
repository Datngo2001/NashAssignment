// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer.Data;
using IdentityServer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using System.Linq;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;

namespace IdentityServer
{
    public class Startup
    {
        public IWebHostEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;

                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
                // .AddInMemoryIdentityResources(Config.IdentityResources)
                // .AddInMemoryApiScopes(Config.ApiScopes)
                // .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>()
                .AddConfigurationStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                })
                .AddOperationalStore(options =>
                {
                    options.ConfigureDbContext = b => b.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                        sql => sql.MigrationsAssembly(migrationsAssembly));
                });

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

                    options.ClientId = Configuration.GetValue<string>("GoogleOAuthClientID");
                    options.ClientSecret = Configuration.GetValue<string>("GoogleOAuthClientSecret");
                });
        }

        public void Configure(IApplicationBuilder app)
        {
            ApplyConfigToDatabase(app);

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

        private async void ApplyConfigToDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();

                var existClients = await context.Clients.AsNoTracking().ToListAsync();
                foreach (var client in Config.Clients)
                {
                    var result = existClients.FirstOrDefault(c => c.ClientId == client.ClientId);
                    if (result == null)
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    else
                    {
                        var clientToUpdate = client.ToEntity();
                        clientToUpdate.Id = result.Id;

                        context.Clients.Update(clientToUpdate);
                    }
                }
                context.SaveChanges();

                var existResources = await context.IdentityResources.AsNoTracking().ToListAsync();
                foreach (var resource in Config.IdentityResources)
                {
                    var result = existResources.FirstOrDefault(c => c.Name == resource.Name);
                    if (result == null)
                    {
                        context.IdentityResources.Add(resource.ToEntity());
                    }
                    else
                    {
                        var resourseToUpdate = resource.ToEntity();
                        resourseToUpdate.Id = result.Id;

                        context.IdentityResources.Update(resourseToUpdate);
                    }
                }
                context.SaveChanges();

                var existApiScopes = await context.ApiScopes.AsNoTracking().ToListAsync();
                foreach (var resource in Config.ApiScopes)
                {
                    var result = existApiScopes.FirstOrDefault(c => c.Name == resource.Name);
                    if (result == null)
                    {
                        context.ApiScopes.Add(resource.ToEntity());
                    }
                    else
                    {
                        var resourseToUpdate = resource.ToEntity();
                        resourseToUpdate.Id = result.Id;

                        context.ApiScopes.Update(resourseToUpdate);
                    }
                }
                context.SaveChanges();
            }
        }
    }
}