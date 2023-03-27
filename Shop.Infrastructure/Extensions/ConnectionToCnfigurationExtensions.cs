using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Connections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Shop.Infrastructure.Extensions
{
    public static class ConnectionToCnfigurationExtensions
    {
        public static async Task ConectionToConfiguration(this IConfigurationBuilder builder)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7079/api/");
            var response = await httpClient.GetAsync("Configurations/GetConfiguration");

            string responseBody = await response.Content.ReadAsStringAsync();
            var configuration = JsonSerializer.Deserialize<IEnumerable<ConfigurationItemDTO>>(responseBody);
            response.EnsureSuccessStatusCode();
            builder.Add((IConfigurationSource)configuration);
        }
    }
}
