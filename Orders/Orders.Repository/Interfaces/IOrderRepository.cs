using Orders.Repository.Entities;
using Shop.Infrastructure.HelperModels;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Interfaces
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<IEnumerable<Order>> GetOrders(OrderFilter filterByClient);
    }
}
