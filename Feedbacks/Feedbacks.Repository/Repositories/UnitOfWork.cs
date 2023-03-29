using Feedbacks.Repository.Context;
using Feedbacks.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Feedbacks.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(FeedbacksContext context)
        {
            _dbContext = context;
            Feedbacks = new FeedbackRepository(context);
        }

        public IFeedbackReporitory Feedbacks { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
