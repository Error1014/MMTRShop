using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Contexts
{
    public class ShopContext: DbContext
    {

        private static ShopContext Context;
        public static ShopContext GetContext()
{
            if (Context == null) Context = new ShopContext();
            return Context;
        }

        public ShopContext() : base(new DbContextOptions<ShopContext>())
        {

        }
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Operator> Operator { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderContent> OrderContent { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<BankCard> BankCard { get; set; }


    }
}
