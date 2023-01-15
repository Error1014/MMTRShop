using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
{
    public class OrderContentRepository:Repository<OrderContent>, IOrderContentRepository
    {
        public OrderContentRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }


    }
}
