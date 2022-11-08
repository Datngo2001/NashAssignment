using DataAccess;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using DataAccess.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//     .AddEntityFrameworkStores<ApiDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.Authority = "https://localhost:7041";

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
        options.MapInboundClaims = true;
    });

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddRoles<AppRole>()
    .AddRoleManager<RoleManager<AppRole>>()
    .AddSignInManager<SignInManager<AppUser>>()
    .AddRoleValidator<RoleValidator<AppRole>>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Customer", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "AssignmentAPI");
        policy.RequireRole("customer", "admin");
    });
    options.AddPolicy("Admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("scope", "AssignmentAPI");
        policy.RequireRole("admin");
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://localhost:5002")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IRatingRepository, RatingRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseCors("AllowOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
