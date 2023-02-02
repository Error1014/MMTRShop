﻿using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class OrderRepository:Repository<Order,Guid>,IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {

        }

        public IEnumerable<Order> GetOrdersByClientId(Guid id)
        {
            return ShopContext.Order.Where(o=>o.ClientId == id).ToList();
        }
    }
}