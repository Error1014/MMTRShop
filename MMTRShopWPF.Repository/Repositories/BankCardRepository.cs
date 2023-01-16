using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repositories
{
    public class BankCardRepository: Repository<BankCard>, IBankCardRepository
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
