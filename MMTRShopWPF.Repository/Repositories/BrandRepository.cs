using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;

namespace MMTRShopWPF.Repository.Repositories
{
    public class BrandRepository:Repository<Brand, Guid>,IBrandRepository
    {
        public BrandRepository(ShopContext context) : base(context)
        {

        }
    }
}
