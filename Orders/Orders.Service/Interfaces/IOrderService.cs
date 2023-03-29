using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Orders.Service.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<IEnumerable<OrderDTO>> GetOrders(OrderFilter filter);
        Task<OrderDTO> GetOrder(Guid orderId);
        Task AddOrder(OrderDTO order);
        Task Save();
        Task Update(OrderDTO orderDTO);
        Task Update(Guid orderId, int statusId);
        Task Remove(Guid orderId);

    }
}
