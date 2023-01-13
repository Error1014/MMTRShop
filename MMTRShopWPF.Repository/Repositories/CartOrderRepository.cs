﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repository
{
    public class CartOrderRepository:Repository<CartOrder>, ICartOrderRepository
    {
        public CartOrderRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}