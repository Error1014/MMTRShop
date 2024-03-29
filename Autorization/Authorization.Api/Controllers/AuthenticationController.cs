﻿using Authorization.Repository.Entities;
using Authorization.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using XAct;
using static System.Net.Mime.MediaTypeNames;

namespace Authorization.Api.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IUserSessionSetter _userSession;
        public AuthenticationController(IConfiguration configuration, IUserService userService, IOptions<JwtOptions> jwtOptions, IUserSessionSetter userSession)
        {
            _userService = userService;
            _configuration = configuration;
            _jwtOptions = jwtOptions;
            _userSession = userSession;
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

        [HttpPost(nameof(Autorize))]
        public async Task<IActionResult> Autorize([FromQuery] string? role)
        {
            UserSession userSession = new UserSession();
            var token = ViewData["Authorization"].ToString();
            if (role==null) return Ok(JsonSerializer.Serialize(userSession));
            var roles = role.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            if (token != "Bearer")
            {
                try
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(_jwtOptions.Value.Key);
                    tokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = _jwtOptions.Value.Issuer,
                        ValidAudience = _jwtOptions.Value.Audience
                    }, out SecurityToken validatedToken);
                    var jwtToken = (JwtSecurityToken)validatedToken;
                    var accountId = Guid.Parse(jwtToken.Claims.FirstOrDefault(x => x.Type == "Id").Value);
                    var myRole = jwtToken.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                    bool isAuthorize = false;
                    foreach (var item in roles)
                    {
                        if (item == myRole)
                        {
                            userSession.Role = myRole;
                            userSession.UserId = accountId;
                            isAuthorize = true;
                            break;
                        }
                    }
                    if (!isAuthorize) StatusCode(403);
                }
                catch
                {
                    return StatusCode(401);
                }
            }
            else
            {
                
                return StatusCode(401);
            }
            return Ok(JsonSerializer.Serialize(userSession));
        }
    }
}
