using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;

namespace MMTRShop.Repository.Repositories
{
    public class BrandRepository:Repository<Brand, Guid>,IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {

        }
    }
}
