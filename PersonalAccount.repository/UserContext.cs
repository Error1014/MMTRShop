using Microsoft.EntityFrameworkCore;
using PersonalAccountMicroservice.PersonalAccount.Repository.Entities;

namespace PersonalAccountMicroservice.PersonalAccount.Repository
{
    public class UserContext:DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().ToTable("Admin");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Operator>().ToTable("Operator");
        }

    }
}
