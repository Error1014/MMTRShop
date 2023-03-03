using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly IConfiguration _configuration;
        public UserSession UserSession { get; set; }
        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration, UserSession userSession)
        {
            _next = next;
            _configuration = configuration;
            UserSession = userSession;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null) 
                AttachAccountToContext(context, userService, token);

            await _next(context);
        }
        private void AttachAccountToContext(HttpContext context, IUserService userService, string token)
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
                var user = userService.GetUser(accountId);
                context.Items["User"] = user;
                UserSession.Id = accountId;
                UserSession.Role = user.GetType().Name;
            }
            catch
            {
            }
        }
    }
}
