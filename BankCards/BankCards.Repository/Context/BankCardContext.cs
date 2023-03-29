using Microsoft.EntityFrameworkCore;

namespace BankCards.Repository.Context
{
    public class BankCardContext : DbContext
    {
        public BankCardContext(DbContextOptions<BankCardContext> options) : base(options)
        {

        }
        public DbSet<BankCard> BankCard { get; set; }

    }
}
