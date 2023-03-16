using AuthorizationMicroservice.Authorization.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationMicroservice.Authorization.Repository
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Operator>().ToTable("Operator");
        }
    }
}
