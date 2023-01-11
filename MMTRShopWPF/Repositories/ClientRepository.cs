using MMTRShopWPF.Model;
using MMTRShopWPF.Repositoryes;

namespace MMTRShopWPF.Repositories
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
