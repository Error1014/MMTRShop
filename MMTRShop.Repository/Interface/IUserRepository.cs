using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using System;

namespace MMTRShop.Repository.Interface
{
    public interface IUserRepository: IRepository<User,Guid>
    {
        Task<IEnumerable<User>> GetUsersPage(BaseFilter filter);
    }
}
