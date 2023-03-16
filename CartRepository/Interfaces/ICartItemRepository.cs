using CartMicroservice.Carts.Repository.Entities;

namespace CartMicroservice.Carts.Repository.Interfaces
{
    public interface ICartItemRepository:IRepository<CartItem,Guid>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCart(Guid cartId);
        Task ClearCart(Guid cartId);
    }
}
