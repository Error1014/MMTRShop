using AuthorizationMicroservice.Authorization.Repository.Entities;
using Shop.Infrastructure.HelperModels;

namespace AuthorizationMicroservice.Authorization.Repository.Interfaces
{
    public interface IUserRepository: IRepository<User,Guid>
    {
        Task<IEnumerable<User>> GetUsersPage(BaseFilter filter);
    }
}
