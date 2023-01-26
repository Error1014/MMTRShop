using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class UserRepository:Repository<User,Guid>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

    }
}
