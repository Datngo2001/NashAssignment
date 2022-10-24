using IdentityServer.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var asembly = typeof(Program).Assembly.GetName().Name;

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = db => db.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(asembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = db => db.UseSqlServer(connectionString, opt => opt.MigrationsAssembly(asembly));
    })
    .AddDeveloperSigningCredential();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
