using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
using System;

namespace MMTRShop.Repository.Interface
{
    public interface IClientRepository: IRepository<Client,Guid>
    {
        Task<IEnumerable<Client>> GetClientsPage(BaseFilter filter);
    }
}
