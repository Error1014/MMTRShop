using Configuration.Repository.Entities;
using ConfigurationMicroservice.Configuration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure;
using Shop.Infrastructure.DTO;

namespace ConfigurationMicroservice.Configuration.Api.Controllers
{
    public class ConfigurationsController : BaseApiController
    {
        private readonly IConfigurationService _configurationService;
        public ConfigurationsController(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }
        [HttpGet(nameof(GetConfiguration))]
        public async Task<IEnumerable<ConfigurationItem>> GetConfiguration()
        {
            return await _configurationService.GetConfiguration();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost(nameof(PostConfiguration))]
        public async Task<IActionResult> PostConfiguration(ConfigurationItem configurationItem)
        {
            await _configurationService.AddConfiguration(configurationItem);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut(nameof(PutConfiguration))]
        public async Task<IActionResult> PutConfiguration(ConfigurationItem configurationItem)
        {
            await _configurationService.UpdateConfiguration(configurationItem);
            return Ok();
        }
    }
}
