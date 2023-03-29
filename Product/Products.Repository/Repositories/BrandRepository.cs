using Products.Repository.Context;
using Products.Repository.Entities;
using Products.Repository.Interfaces;
using Shop.Infrastructure.Repository;

namespace Products.Repository.Repositories
{
    public class BrandRepository : Repository<Brand, Guid>, IBrandRepository
    {
        public BrandRepository(ProductContext context) : base(context)
        {

        }
    }
}
