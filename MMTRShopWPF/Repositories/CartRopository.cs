using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories
{
    public class CartRopository : Repository<Cart>, ICartRepository
    {
        public CartRopository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        

        public List<Cart> GetKorzineByIdClient(Guid id)
        {
            return ShopContext.Cart.Where(k=>k.ClientId==id).ToList();
        }
    }
}
