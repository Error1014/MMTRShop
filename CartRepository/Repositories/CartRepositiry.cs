using CartMicroservice.Carts.Repository.Entities;
using CartMicroservice.Carts.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.Repository;

namespace CartMicroservice.Carts.Repository.Repositories
{
    public class CartRepositiry : Repository<Cart, Guid>, ICartRepository
    {
        public CartRepositiry(DbContext context) : base(context)
        {
        }

        public async Task<Cart> GetCartByClient(Guid clientId)
        {
            return await Set.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
        }
    }
}
