using Microsoft.EntityFrameworkCore;
using Orders.Repository.Context;
using Orders.Repository.Entities;
using Orders.Repository.Interfaces;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Repositories
{
    public class OrderRepository : Repository<Order, Guid>, IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext context) : base(context)
        {
            _orderContext = context;
        }

        public async Task<IEnumerable<Order>> GetOrders(OrderFilter filter)
        {
            var query = Set;
            if (filter.ClientId.HasValue)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            if (filter.StatusId.HasValue)
            {
                query = query.Where(x => x.StatusId == filter.StatusId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
