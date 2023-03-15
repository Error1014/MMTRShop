using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using MMTRShop.Repository.Entities;

namespace MTTRShopAPI.Middleware.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly IConfiguration? _configuration;
        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IServiceProvider serviceProvider)
        {
            var userService = serviceProvider.GetService<IUserService>();
            var userSession = serviceProvider.GetService<IUserSessionSetter>();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = _configuration["Jwt:Issuer"],
                        ValidAudience = _configuration["Jwt:Audience"]
                    }, out SecurityToken validatedToken);
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var accountId = Guid.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                    var role = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                    //context.Items["User"] = new User(accountId);
                    userSession.UserId = accountId;
                    userSession.Role = role;
                }
                catch
                {
                    throw new Exception("Error");
                }
            } 

            await _next(context);
        }
    }
}
