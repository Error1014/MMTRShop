using Microsoft.OpenApi.Models;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using Shop.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Configuration.Services;
using Carts.Repository.Interfaces;
using Carts.Repository.Repositories;
using Carts.Repository;
using Carts.Services;
using Shop.Infrastructure.HelperModels;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Shop.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegistrationDbContext<CartContext>(builder.Configuration);


await builder.Configuration.AddConfigurationApiSource(builder.Configuration);
builder.Services.Configure<UriEndPoint>(
    builder.Configuration.GetSection("AuthorizationService")); 
builder.Services.Configure<SettingsConfiguration>(
     builder.Configuration.GetSection("SettingsConfiguration"));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<ICartService, CartService>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionGetter>(serv => serv.GetRequiredService<UserSession>());
builder.Services.AddScoped<IUserSessionSetter>(serv => serv.GetRequiredService<UserSession>());
builder.Services.AddMemoryCache();
builder.Services.AddAutoMapper(typeof(MappingProfile));
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();

