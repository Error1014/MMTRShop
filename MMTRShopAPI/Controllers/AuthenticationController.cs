using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure.HelperModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;

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
                
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, person.Login) };
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
                username = person.Login
            };

            return Results.Json(response);
        }
    }
}
