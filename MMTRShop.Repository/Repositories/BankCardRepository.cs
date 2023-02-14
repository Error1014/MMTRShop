using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class BankCardRepository: Repository<BankCard, Guid>, IBankCardRepository
    {
        public BankCardRepository(ShopContext context) : base(context)
        {

        }
    }
}
