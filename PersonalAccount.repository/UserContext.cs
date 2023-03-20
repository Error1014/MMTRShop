using Microsoft.EntityFrameworkCore;
using PersonalAccount.Repository.Entities;

namespace PersonalAccount.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("Client");
        }

    }
}
