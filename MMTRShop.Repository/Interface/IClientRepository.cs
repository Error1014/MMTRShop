using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using System;

namespace MMTRShop.Repository.Interface
{
    public interface IClientRepository: IRepository<Client,Guid>
    {
        Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter);
    }
}
