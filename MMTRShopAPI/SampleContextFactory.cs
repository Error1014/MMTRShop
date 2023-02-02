using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;

namespace MMTRShopAPI
{
    public class SampleContextFactory
    {
        private const string ConnectionString =
            "Server=(localdb)\\mssqllocaldb;Database=EfCoreInActionDb;Trusted_Connection=True;MultipleActiveResultSets=true";

        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();
            optionsBuilder.UseSqlServer(ConnectionString,
                b => b.MigrationsAssembly("MMTRShopAPI"));

            return new ShopContext(optionsBuilder.Options);
        }
    }
}
