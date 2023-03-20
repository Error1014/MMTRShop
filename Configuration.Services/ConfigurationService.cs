using Configuration.Repository.Entities;
using Configuration.Repository.Interfaces;
using Microsoft.Extensions.Options;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Configuration.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public readonly IUnitOfWork _unitOfWork;
        public ConfigurationService( IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ConfigurationItem>> GetConfiguration()
        {
            return await _unitOfWork.ConfigurationItems.GetAllAsync();

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
