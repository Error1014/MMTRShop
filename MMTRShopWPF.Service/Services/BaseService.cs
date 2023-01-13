using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repository;

namespace MMTRShopWPF.Service.Services
{
    public class BaseService
    {
        protected static UnitOfWork UnitOfWork = new UnitOfWork(new ShopContext());
    }
}
