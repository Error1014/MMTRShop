using PersonalAccount.Repository.Entities;
using Shop.Infrastructure.HelperModels;

namespace PersonalAccount.Repository.Interfaces
{
    public interface IClientRepository : IRepository<Client, Guid>
    {
        Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter);
    }
}
