using Shop.Infrastructure.DTO;

namespace CartMicroservice.Carts.Services
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDTO>> GetCartItemsDTO();
        Task<CartItemDTO> GetCartItem(Guid cartId);
        Task AddProductInCart(Guid productId);
        Task Update(CartItemDTO cartDTO);
        Task RemoveProductInCart(Guid cartItemId);
        Task CartMinusOneProduct(Guid id);
        Task CartPlusOneProduct(Guid id);
        Task ClearCart();
    }
}
