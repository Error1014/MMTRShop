using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class CategoryRepository : Repository<Category,Guid>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {

        }

    }
}
