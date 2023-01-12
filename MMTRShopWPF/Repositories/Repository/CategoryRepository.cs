using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Interface;

namespace MMTRShopWPF.Repositories.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}
