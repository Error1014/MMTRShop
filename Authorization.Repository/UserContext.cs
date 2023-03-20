using Authorization.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authorization.Repository
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
