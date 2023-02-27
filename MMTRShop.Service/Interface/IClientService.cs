using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.DTO;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDTO>> GetPageClients(BaseFilter filter);
        Task<ClientDTO> GetClient(Guid id);
        Task AddClient(ClientDTO client);
        Task RemoveClient(Guid clientId);
        Task Update(Guid clientId,ClientDTO client);
        Task Save();
    }
}
