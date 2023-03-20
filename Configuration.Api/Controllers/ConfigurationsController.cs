using Configuration.Repository.Entities;
using Configuration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Shop.Infrastructure;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Configuration.Api.Controllers
{
    public class ConfigurationsController : BaseApiController
    {
        private readonly IConfigurationService _configurationService;
        private readonly IOptions<JwtOptions> _jwtOptions;
        public ConfigurationsController(IConfigurationService configurationService, IOptions<JwtOptions> options)
        {
            _configurationService = configurationService;
            _jwtOptions = options;
        }
        [HttpGet(nameof(GetJwtOptions))]
        public async Task<IOptions<JwtOptions>> GetJwtOptions()
        {
            return _jwtOptions;
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
