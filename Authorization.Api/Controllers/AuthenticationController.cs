﻿using Authorization.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Authorization.Api.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<JwtOptions> _jwtOptions;
        public AuthenticationController(IConfiguration configuration, IUserService userService, IOptions<JwtOptions> jwtOptions)
        {
            _userService = userService;
            _configuration = configuration;
            _jwtOptions = jwtOptions;
        }
        [HttpPost(nameof(Registration))]
        public async Task<IActionResult> Registration(UserDTO userDTO)
        {
            await _userService.AddUser(userDTO);
            return Ok();
        }
        [HttpPost]
        public async Task<IResult> Login(LoginPasswordModel loginPasswordModel)
        {
            // находим пользователя 
            var person = await _userService.GetUser(loginPasswordModel);

            var role = await _userService.GetRole(person.Id);

            var claims = new List<Claim>
            {
                new Claim("Id", person.Id.ToString()),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,role)
            };
            // создаем JWT-токен
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Value.Key);
            var jwt = new JwtSecurityToken(
                    issuer: _jwtOptions.Value.Issuer,
                    audience: _jwtOptions.Value.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                id = person.Id,
                accessToken = encodedJwt,
                username = person.Login,
                role
            };

            return Results.Json(response);
        }
    }
}
