using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
{
    public class OrderContentRepository:Repository<OrderContent,Guid>, IOrderContentRepository
    {
        public OrderContentRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return base.ShopContext as ShopContext; }
        }


    }
}
