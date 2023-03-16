using AuthorizationMicroservice.Authorization.Repository.Entities;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace AuthorizationMicroservice.Authorization.Services
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
