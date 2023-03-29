using Feedbacks.Repository;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks.Repository.Context
{
    public class FeedbacksContext : DbContext
    {
        public FeedbacksContext(DbContextOptions<FeedbacksContext> options) : base(options)
        {

        }
        public DbSet<Feedback> Feedback { get; set; }

    }
}
