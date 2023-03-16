using CartMicroservice.Carts.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartMicroservice.Carts.Repository
{
    public class CartContext : DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItem { get; set; }

    }
}
