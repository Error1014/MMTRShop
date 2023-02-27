using MMTRShop.Repository.Entities;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
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
        Task<User> GetUser(LoginPasswordModel loginPassword);
        Task AddUser(UserDTO user);
        Task RemoveUser(Guid userId);
        Task Update(UserDTO user);
        Task Save();
    }
}
