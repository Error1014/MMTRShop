using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.DTO;

namespace AuthorizationMicroservice.Authorization.Services
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetPageClients(BaseFilter filter);
        Task<ClientDTO> GetClient(Guid id);
        Task AddClient(ClientDTO client);
        Task RemoveClient(Guid clientId);
        Task Update(ClientDTO client);
        Task Save();
    }
}
