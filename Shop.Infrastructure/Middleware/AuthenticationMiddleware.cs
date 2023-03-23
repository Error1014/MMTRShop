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

namespace Shop.Infrastructure.Middleware.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next; 
        private HttpClient _httpClient = new HttpClient();
        public AuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            _httpClient = new HttpClient();
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            HttpResponseMessage response = await _httpClient.PostAsync($"https://localhost:7226/api/Authentication/Autorize?role=Client", JsonContent.Create(""));
            string responseBody = await response.Content.ReadAsStringAsync();
            response.EnsureSuccessStatusCode();
            await _next(context);
        }
    }
}
