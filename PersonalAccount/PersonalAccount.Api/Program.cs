using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using Shop.Infrastructure.Extensions;
using PersonalAccount.Repository.Repositories;
using PersonalAccount.Repository;
using PersonalAccount.Repository.Interfaces;
using PersonalAccount.Services;
using Shop.Infrastructure.HelperModels;
using Configuration.Services;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.RegistrationDbContext<UserContext>(builder.Configuration);
builder.Host
       .ConfigureAppConfiguration((context,
                                   builder) =>
       {
           var config = builder.Build();
           string conectionString = "Server=(localdb)\\mssqllocaldb;Database=MMTRShopConfiguration;Trusted_Connection=True;MultipleActiveResultSets=true";
           builder.AddEfConfiguration(optionsBuilder =>
           {
               optionsBuilder.UseSqlServer(conectionString);

           });
       });
builder.Services.Configure<UriEndPoint>(
    builder.Configuration.GetSection("AuthorizationService"));
builder.Services.Configure<SettingsConfiguration>(
builder.Configuration.GetSection("SettingsAPI"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<UserSession>();
builder.Services.AddScoped<IUserSessionGetter>(serv => serv.GetRequiredService<UserSession>());
builder.Services.AddScoped<IUserSessionSetter>(serv => serv.GetRequiredService<UserSession>());

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAuthorization();

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


app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.Run();