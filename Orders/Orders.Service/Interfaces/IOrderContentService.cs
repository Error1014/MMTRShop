using Shop.Infrastructure.DTO;

namespace Orders.Service.Interfaces
{
    public interface IOrderContentService
    {
        Task AddOrderContent(OrderContentDTO orderContentDTO);
        Task Remove(Guid orderId);
        Task Update(OrderContentDTO order);
        Task Save();
        Task<IEnumerable<OrderContentDTO>> GetOrderContents(Guid orderId);
    }
}
