﻿using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Shop.Infrastructure.Extensions
{
    public static class ConnectionToConfigurationExtensions
    {
        public static async Task AddConfigurationApiSource(this IConfigurationBuilder builder, IConfiguration configuration)
        {
            HttpClient httpClient = new HttpClient();
            UriEndPoint uriEndPoint = new UriEndPoint();
            uriEndPoint = configuration.GetSection("Configuration")
                                                     .Get<UriEndPoint>();
            httpClient.BaseAddress = new Uri(uriEndPoint.BaseAddress);
            var response = await httpClient.GetAsync(uriEndPoint.Uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var configurationItemsList = JsonSerializer.Deserialize<IEnumerable<ConfigurationItemDTO>>(responseBody);
            Dictionary<string, string> dictonary = new Dictionary<string, string>();
            foreach (var item in configurationItemsList)
            {
                dictonary.Add(item.key,item.value);
            }
            builder.Add(new DictionaryConfigurationSource(dictonary));
        }
    }
}
