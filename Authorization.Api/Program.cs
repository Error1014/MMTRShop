using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Middleware.Middleware;
using Microsoft.Extensions.Configuration;
using Shop.Infrastructure.Extensions;
using Authorization.Repository.Interfaces;
using Authorization.Repository.Repositories;
using Authorization.Repository;
using Authorization.Services.Interfaces;
using Authorization.Services;
using Authorization.Services.Services;
using Configuration.Services;
using Shop.Infrastructure.HelperModels;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegistrationDbContext<UserContext>(builder.Configuration);
builder.Host
       .ConfigureAppConfiguration((hostingContext, config) =>
       {
           config.AddEfConfiguration(
               options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MMTRShopConfiguration;Trusted_Connection=True;MultipleActiveResultSets=true"));
       });
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
builder.Services.Configure<JwtOptions>(
builder.Configuration.GetSection("JwtOptions"));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionGetter>(serv => serv.GetRequiredService<UserSession>());
builder.Services.AddScoped<IUserSessionSetter>(serv => serv.GetRequiredService<UserSession>());

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthorization();
builder.Services.SetJwtOptions(builder.Configuration);

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