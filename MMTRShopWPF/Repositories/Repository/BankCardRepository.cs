using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositories.Repository
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
