using AutoMapper;
using Shop.Infrastructure.DTO;
using MMTRShop.Repository;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Interface;

namespace MMTRShop.Service.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUserSessionGetter _userSession;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, UserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSession = userSession;
        }
        private async Task<Cart> GetCart()
        {
            return await _unitOfWork.Carts.GetCartByClient(_userSession.GetId());
        }
        public async Task<IEnumerable<CartItemDTO>> GetCartItemsDTO()
        {
            var cart = await GetCart();
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
    }
}
