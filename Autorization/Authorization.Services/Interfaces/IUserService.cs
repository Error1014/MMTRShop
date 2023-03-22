using Authorization.Repository.Entities;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Authorization.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetPageUser(BaseFilter filter);
        Task<UserDTO> GetUser(Guid id);
        Task<User> GetUser(LoginPasswordModel loginPassword);
        Task<string> GetRole(Guid userId);
        Task AddUser(UserDTO user);
        Task RemoveUser(Guid userId);
        Task Update(UserDTO user);
        Task Save();
    }
}
