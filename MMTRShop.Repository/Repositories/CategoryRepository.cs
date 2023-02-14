using MMTRShop.Model.Models;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class CategoryRepository : Repository<Category,Guid>, ICategoryRepository
    {
        public CategoryRepository(ShopContext context) : base(context)
        {

        }

    }
}
