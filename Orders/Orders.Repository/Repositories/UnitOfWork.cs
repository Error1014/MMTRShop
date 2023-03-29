using Microsoft.EntityFrameworkCore;
using Orders.Repository.Context;
using Orders.Repository.Interfaces;

namespace Orders.Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public UnitOfWork(OrderContext context)
        {
            _dbContext = context;
            Orders = new OrderRepository(context);
            OrderContents = new OrderContentRepository(context);
            Status = new StatusRepository(context);
        }


        public IOrderRepository Orders { get; private set; }

        public IOrderContentRepository OrderContents { get; private set; }

        public IStatusRepository Status { get; private set; }

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
