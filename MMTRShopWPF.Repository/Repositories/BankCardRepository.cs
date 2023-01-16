using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class BankCardRepository: Repository<BankCard, Guid>, IBankCardRepository
    {
        public BankCardRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return base.ShopContext as ShopContext; }
        }
    }
}
