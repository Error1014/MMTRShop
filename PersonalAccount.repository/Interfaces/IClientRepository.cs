using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;
using Shop.Infrastructure.HelperModels;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Interfaces
{
    public interface IClientRepository: IRepository<Client,Guid>
    {
        Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter);
    }
}
