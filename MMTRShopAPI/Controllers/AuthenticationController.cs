using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure.HelperModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;
using MMTRShop.Repository.Entities;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost] 
        public async Task<IResult> Login(LoginPasswordModel loginPasswordModel)
{
            // находим пользователя 
            var person =await _userService.GetUser(loginPasswordModel);
            string role = "";
            if (person is Client) role = "Client";
            else if (person is Admin) role = "Admin";
            else if (person is Operator) role = "Operator";
            var claims = new List<Claim> 
            { 
                new Claim(ClaimTypes.Name, person.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,role)
            };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = person.Login,
                role = role
            };

            return Results.Json(response);
        }
    }
}
