using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repositories.Repository
{
    public class CartRopository : Repository<Cart,Guid>, ICartRepository
    {
        public CartRopository(ShopContext context) : base(context)
        {

        }


        public IEnumerable<Cart> GetCartByIdClient(Guid id)
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
