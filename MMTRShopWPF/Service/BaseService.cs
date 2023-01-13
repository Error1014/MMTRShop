using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories.Repository;

namespace MMTRShopWPF.Service.Services
{
    public class BaseService
    {
        protected static UnitOfWork UnitOfWork = new UnitOfWork(new ShopContext());
    }
}
