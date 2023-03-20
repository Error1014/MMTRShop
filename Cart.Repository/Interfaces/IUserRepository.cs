using Authorization.Repository.Entities;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Repository;

namespace Authorization.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<string> GetRole(Guid userId);
        Task<IEnumerable<User>> GetUsersPage(BaseFilter filter);
    }
}
