using CartMicroservice.Carts.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace CartMicroservice.Carts.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart, Guid>
    {
        Task<Cart> GetCartByClient(Guid clientId);
    }
}
