using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class UserRepository:Repository<User,Guid>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

    }
}
