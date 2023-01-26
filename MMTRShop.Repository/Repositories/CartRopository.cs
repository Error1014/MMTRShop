using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repositories.Repository
{
    public class CartRopository : Repository<Cart,Guid>, ICartRepository
    {
        public CartRopository(ShopContext context) : base(context)
        {

        }


        public IEnumerable<Cart> GetCartByClient(Client client)
        {
            return ShopContext.Cart.Where(k=>k.ClientId==client.Id).ToList();
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
