using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repositories
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

    }
}
