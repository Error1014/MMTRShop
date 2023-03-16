using AuthorizationMicroservice.Authorization.Repository.Entities;
using Shop.Infrastructure.HelperModels;

namespace AuthorizationMicroservice.Authorization.Repository.Interfaces
{
    public interface IClientRepository: IRepository<Client,Guid>
    {
        Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter);
    }
}
