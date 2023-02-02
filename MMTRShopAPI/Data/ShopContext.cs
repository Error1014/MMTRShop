using Microsoft.EntityFrameworkCore;
using MMTRShop.Model.Models;

namespace MMTRShopAPI.Data
{
    public class ShopContext : DbContext
    {
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
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<BankCard> BankCard { get; set; }


    }
}
