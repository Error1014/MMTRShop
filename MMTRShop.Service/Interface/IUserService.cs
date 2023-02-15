using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetPageUser(BaseFilter filter);
        Task<UserDTO> GetUser(Guid id);
        Task AddUser(UserDTO product);
        Task RemoveUser(Guid productId);
        Task Update(UserDTO product);
        Task Save();
    }
}
