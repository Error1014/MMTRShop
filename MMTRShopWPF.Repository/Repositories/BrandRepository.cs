﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repositories
{
    public class BrandRepository:Repository<Brand>,IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}
