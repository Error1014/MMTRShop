using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Model.Models;
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
        Task Update(ClientDTO client);
        Task Save();
    }
}
