using Orders.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Interfaces
{
    public interface IOrderContentRepository : IRepository<OrderContent, Guid>
    {
        Task<IEnumerable<OrderContent>> GetOrderContentsByOrderId(Guid orderId);

        Task<IEnumerable<OrderContent>> GetCanceledOrderByClientId(Guid clientId);
    }
}
