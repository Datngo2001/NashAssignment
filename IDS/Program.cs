using IdentityServer4.Models;
using IdentityServer4.Test;
using IDS;
using IDS.Data;
using IDS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (seed)
{
    Console.WriteLine("Seeding database...");
    SeedData.Seed(connectionString);
    Console.WriteLine("Done seeding database.");
}

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(connectionString,
                    sqlOptions => sqlOptions.MigrationsAssembly("IDS")));

builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<AppUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly("IDS"));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = builder =>
            builder.UseSqlite(connectionString, opt => opt.MigrationsAssembly("IDS"));
    })
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseIdentityServer();

app.Run();
