using Carts.Repository.Entities;
using Shop.Infrastructure.Repository;

namespace Carts.Repository.Interfaces
{
    public interface ICartRepository : IRepository<Cart, Guid>
    {
        Task<Cart> GetCartByClient(Guid clientId);
    }
}
