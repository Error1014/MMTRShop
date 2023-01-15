﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
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

        public List<Order> GetOrdersByClientId(Guid id)
        {
            return ShopContext.Order.Where(o=>o.ClientId == id).ToList();
        }
    }
}
