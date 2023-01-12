using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;

namespace MMTRShopWPF.Repositories.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}
