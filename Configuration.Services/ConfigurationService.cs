using Configuration.Repository.Entities;
using Configuration.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Shop.Infrastructure.DTO;

namespace ConfigurationMicroservice.Configuration.Services
{
    public class ConfigurationService:IConfigurationService
    {
        private readonly IOptions<SettingsConfiguration> _optionsDelegate;
        public readonly IUnitOfWork _unitOfWork;
        public ConfigurationService(IOptions<SettingsConfiguration> optionsDelegate, IUnitOfWork unitOfWork)
        {
            _optionsDelegate = optionsDelegate;
            _unitOfWork = unitOfWork;
        }

        public async Task<IOptions<SettingsConfiguration>> GetConfiguration()
        {
            return _optionsDelegate;
            
        }

        public async Task AddConfiguration(ConfigurationItem configurationItem)
        {
            await _unitOfWork.ConfigurationItems.AddAsync(configurationItem);
            await _unitOfWork.ConfigurationItems.SaveAsync();
        }

        public async Task UpdateConfiguration(ConfigurationItem configurationItem)
        {
            _unitOfWork.ConfigurationItems.Update(configurationItem);
            await _unitOfWork.ConfigurationItems.SaveAsync();
        }
    }
}
