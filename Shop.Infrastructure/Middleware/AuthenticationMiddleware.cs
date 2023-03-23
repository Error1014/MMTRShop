using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Infrastructure.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Shop.Infrastructure.HelperModels;
using System.Net.Http.Json;
using System.Net.Http;
using XAct;
using Shop.Infrastructure.DTO;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Shop.Infrastructure.Middleware.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private HttpClient _httpClient = new HttpClient();
        private readonly UriEndPoint uriEndPoint;
        public AuthenticationMiddleware(RequestDelegate next, IOptions<UriEndPoint> options)
        {
            _next = next;
            uriEndPoint = options.Value;

        }

        public async Task Invoke(HttpContext context, IUserSessionSetter userSession)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(uriEndPoint.BaseAddress);
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage response = await _httpClient.PostAsync(uriEndPoint.Uri, JsonContent.Create(""));

            string responseBody = await response.Content.ReadAsStringAsync();
            var session = JsonSerializer.Deserialize<UserSession>(responseBody);
            userSession.UserId = session.UserId;
            userSession.Role = session.Role;
            response.EnsureSuccessStatusCode();
            await _next(context);
        }

    }

}
