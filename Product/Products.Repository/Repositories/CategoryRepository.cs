using Products.Repository.Context;
using Products.Repository.Entities;
using Products.Repository.Interfaces;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Repositories
{
    public class CategoryRepository : Repository<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
        {

        }

    }
}
