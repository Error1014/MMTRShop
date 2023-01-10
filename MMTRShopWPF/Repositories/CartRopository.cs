using MMTRShopWPF.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
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

        

        public List<Cart> GetKorzineByIDUser(Guid id)
        {
            return ShopContext.Cart.Where(k=>k.UserId==id).ToList();
        }
    }
}
