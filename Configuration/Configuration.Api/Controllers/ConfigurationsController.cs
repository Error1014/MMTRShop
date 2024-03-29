﻿using Configuration.Repository;
using Configuration.Repository.Entities;
using Configuration.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Configuration.Api.Controllers
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
        [RoleAuthorize("Admin")]
        [HttpPost(nameof(PostConfiguration))]
        public async Task<IActionResult> PostConfiguration(ConfigurationItem configurationItem)
        {
            await _configurationService.AddConfiguration(configurationItem);
            return Ok();
        }
        [RoleAuthorize("Admin")]
        [HttpPut(nameof(PutConfiguration))]
        public async Task<IActionResult> PutConfiguration(ConfigurationItem configurationItem)
        {
            await _configurationService.UpdateConfiguration(configurationItem);
            return Ok();
        }
    }
}
