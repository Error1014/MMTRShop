using Microsoft.EntityFrameworkCore;
using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Contexts
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
