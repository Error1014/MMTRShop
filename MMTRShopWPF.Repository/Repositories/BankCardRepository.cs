﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repository
{
    public class BankCardRepository: Repository<BankCard>, IBankCardRepository
    {
        public BankCardRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}