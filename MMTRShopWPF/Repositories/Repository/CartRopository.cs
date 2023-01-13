using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repositories.Repository
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

        

        public List<Cart> GetCartByIdClient(Guid id)
        {
            return ShopContext.Cart.Where(k=>k.ClientId==id).ToList();
        }
    }
}
