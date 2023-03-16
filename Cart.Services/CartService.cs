using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Interface;
using Shop.Infrastructure.Exceptions;
using CartMicroservice.Carts.Repository.Interfaces;
using CartMicroservice.Carts.Repository.Entities;
using AutoMapper;

namespace CartMicroservice.Carts.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserSessionGetter _userSession;
        //private readonly IClientSettingsService _configurationService;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, IUserSessionGetter userSession/*, IClientSettingsService configuration*/)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSession = userSession;
            //_configurationService = configuration;  
        }
        private async Task<Cart> GetCart()
        {
            var cart = await _unitOfWork.Carts.GetCartByClient(_userSession.UserId);
            if (cart == null)
            {
                await _unitOfWork.Carts.AddAsync(new Cart(_userSession.UserId));
            }
            return await _unitOfWork.Carts.GetCartByClient(_userSession.UserId);
        }
        public async Task<IEnumerable<CartItemDTO>> GetCartItemsDTO()
        {
            var cart = await GetCart();
            if (cart == null)
            {
                await _unitOfWork.Carts.AddAsync(new Cart(_userSession.UserId));
            }
            var items = await _unitOfWork.CartItems.GetCartItemsByCart(cart.Id);
            var result = _mapper.Map<IEnumerable<CartItemDTO>>(items);
            return result;
        }
        public async Task<CartItemDTO> GetCartItem(Guid id)
        {
            var cart = await _unitOfWork.CartItems.GetByIdAsync(id);
            var result = _mapper.Map<CartItemDTO>(cart);
            return result;
        }
        public async Task AddProductInCart(Guid productId)
        {
            var cart = await GetCart();
            var items = await _unitOfWork.CartItems.GetCartItemsByCart(cart.Id);
            bool isNew = true;
            for (int i = 0; i < items.ToList().Count; i++)
            {
                if (items.ToList()[i].ProductId == productId)
                {
                    isNew = false;
                    await CheckRestriction();
                    items.ToList()[i].ProductCount++;
                    _unitOfWork.CartItems.Update(items.ToList()[i]);
                }
            }
            if (isNew)
            {
                _unitOfWork.CartItems.Add(new CartItem(cart.Id, productId, 1));
            }
            await Save();
        }
        public async Task CartMinusOneProduct(Guid cartId)
        {
            var item = await _unitOfWork.CartItems.GetByIdAsync(cartId);
            if (item.ProductCount > 0)
            {
                item.ProductCount--;
            }
            if (item.ProductCount == 0)
            {
                _unitOfWork.CartItems.Remove(item);
            }
            _unitOfWork.CartItems.Update(item);
            await Save();
        }
        public async Task CartPlusOneProduct(Guid cartId)
        {
            var item = await _unitOfWork.CartItems.GetByIdAsync(cartId);
            await CheckRestriction();
            item.ProductCount++;
            _unitOfWork.CartItems.Update(item);
            await Save();
        }
        public async Task ClearCart()
        {
            var cart = await GetCart();
            await _unitOfWork.CartItems.ClearCart(cart.Id);
            await Save();
        }
        public async Task RemoveProductInCart(Guid cartItemId)
        {
            _unitOfWork.CartItems.Remove(cartItemId);
            await Save(); 
        }
        public async Task Update(CartItemDTO cartDTO)
        {
            var cart = _mapper.Map<CartItem>(cartDTO);
            _unitOfWork.CartItems.Update(cart);
            await Save();
        }
        private async Task Save()
        {
            await _unitOfWork.CartItems.SaveAsync();
        }

        private async Task CheckRestriction()
        {
            var cartItems =await GetCartItemsDTO();
            var count = cartItems.Sum(x=>x.ProductCount);
            var limit = 10; /*_configurationService.SettingsAPI.RestrictionOfGoodsInCart;*/
            if (count>= limit)
            {
                throw new RestrictionOfGoodsException($"Лимит вместимости корзины {limit} товаров");;
            }
        }
    }
}
