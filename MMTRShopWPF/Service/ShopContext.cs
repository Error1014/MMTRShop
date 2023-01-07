using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class ShopContext: DbContext
    {

        private static ShopContext Context;
        public static ShopContext GetContext()
        {
            if (Context == null) Context = new ShopContext();
            return Context;
        }


        public ShopContext() : base("MMPRShopDB") 
        {
            Database.SetInitializer<ShopContext>(new CreateDatabaseIfNotExists<ShopContext>());
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Korzine> Korzine { get; set; }


    }
}
