using CartMicroservice.Carts.Repository.Entities;

namespace CartMicroservice.Carts.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart, Guid>
    {
        Task<Cart> GetCartByClient(Guid clientId);
    }
}
