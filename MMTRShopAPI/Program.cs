using Microsoft.EntityFrameworkCore;
using MMTRShop.Repository.Entities;
using MMTRShop.Service.Services;
using MMTRShop.Repository.Repositories;
using MMTRShop.Repository.Interface;
using MMTRShop.Service.Interface;
using MMTRShop.Repository.Contexts;
using MMTRShop.Service;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using Microsoft.Extensions.Configuration;
using MTTRShopAPI.Middleware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found."));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<SettingsAPI>(
    builder.Configuration.GetSection("SettingsAPI"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IProductService, ProductService>()
    .AddScoped<IUserService, UserService>()
    .AddScoped<IBankCardService, BankCardService>()
    .AddScoped<IBrandService, BrandService>()
    .AddScoped<ICartService, CartService>()
    .AddScoped<ICategoryServise, CategoryService>()
    .AddScoped<IClientService, ClientService>()
    .AddScoped<IFavouriteService, FavouriteService>()
    .AddScoped<IFeedbackService, FeedbackService>()
    .AddScoped<IOrderService, OrderService>()
    .AddScoped<IOrderContentService, OrderContentService>()
    .AddScoped<IStatusService, StatusService>()
    .AddScoped<IClientSettingsService, ClientSettingsService>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionGetter>(serv => serv.GetRequiredService<UserSession>());
builder.Services.AddScoped<IUserSessionSetter>(serv => serv.GetRequiredService<UserSession>());

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.Run();

