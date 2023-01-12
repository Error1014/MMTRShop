using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;

namespace MMTRShopWPF.Repositories.Repository
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
