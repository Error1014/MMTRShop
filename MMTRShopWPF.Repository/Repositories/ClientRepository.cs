using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
namespace MMTRShopWPF.Repository.Repository
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
