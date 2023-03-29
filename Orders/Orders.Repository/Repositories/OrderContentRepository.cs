using Orders.Repository.Context;
using Orders.Repository.Entities;
using Orders.Repository.Interfaces;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Repositories
{
    public class OrderContentRepository : Repository<OrderContent, Guid>, IOrderContentRepository
    {
        private readonly OrderContext _rderContext;
        public OrderContentRepository(OrderContext context) : base(context)
        {
            _rderContext = context;
        }

        public async Task<IEnumerable<OrderContent>> GetCanceledOrderByClientId(Guid clientId)
        {
            return _rderContext.OrderContent.Where(o => o.Order.Status.Title == "Получен" && o.Order.ClientId == clientId);
        }

        public async Task<IEnumerable<OrderContent>> GetOrderContentsByOrderId(Guid orderId)
        {
            return _rderContext.OrderContent.Where(o => o.OrderId == orderId);
        }
    }
}
