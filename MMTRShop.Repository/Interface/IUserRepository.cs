using MMTRShop.Model.Models;
using System;

namespace MMTRShop.Repository.Interface
{
    public interface IUserRepository: IRepository<User,Guid>
    {
    }
}
