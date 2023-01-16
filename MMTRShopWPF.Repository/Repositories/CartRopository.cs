using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using MMTRShopWPF.Repository.Repositories;
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

        public int GetCountPage(int sizePage)
        {
            int countPage = 0;
            if (ShopContext.GetContext().Product.Count() % sizePage == 0)
            {
                countPage = ShopContext.GetContext().Product.Count() / sizePage;
            }
            else
            {
                countPage = ShopContext.GetContext().Product.Count() / sizePage + 1;
            }
            return countPage;
        }
    }
}
