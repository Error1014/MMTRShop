﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repository
{
    public class OrderRepository:Repository<Order>,IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}