using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;

namespace MMTRShopWPF.Repositories.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}
