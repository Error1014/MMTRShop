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

namespace MMTRShop.Service.Services
{
    public class CartService : ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CartDTO>> GetCartsDTO(FilterByClient filter)
        {
            var carts = await _unitOfWork.Carts.GetCarts(filter);
            var result = _mapper.Map<IEnumerable<CartDTO>>(carts);
            return result;
        }
        private async Task<IEnumerable<Cart>> GetCarts(Guid clientId)
        {
            return await _unitOfWork.Carts.GetCartsByClient(clientId);
        }
        public async Task<IEnumerable<CartDTO>> GetCartsDTO(Guid clientId)
        {
            var carts = await GetCarts(clientId);
            var result = _mapper.Map<IEnumerable<CartDTO>>(carts);
            return result;
        }
        public async Task<CartDTO> GetCart(Guid id)
        {
            var cart = await _unitOfWork.Carts.GetByIdAsync(id);
            var result = _mapper.Map<CartDTO>(cart);
            return result;
        }
        public async Task<CartDTO> GetCartByClientIdAndProductId(Guid clientId,Guid productId)
        {
            var cart = await _unitOfWork.Carts.GetCartByClientIdAndProductId(clientId,productId);
            var result = _mapper.Map<CartDTO>(cart);
            return result;
        }
        public async Task AddProductInCart(CartDTO cartDTO)
        {
            var myKorzine = await _unitOfWork.Carts.GetCartsByClient(cartDTO.ClientId);
            var korzine = myKorzine.ToList();
            bool isNew = true;
            for (int i = 0; i < korzine.Count; i++)
            {
                if (korzine[i].ProductId == cartDTO.ProductId)
                {
                    isNew = false;
                    korzine[i].ProductCount++;
                }
            }
            if (isNew)
            {
                _unitOfWork.Carts.Add(new Cart(cartDTO.ClientId, cartDTO.ProductId, 1));
            }
            await Save();
        }
        public async Task CartMinusOneProduct(Guid id)
        {
            var item = await _unitOfWork.Carts.GetByIdAsync(id);
            if (item.ProductCount > 0)
            {
                item.ProductCount--;
            }
            if (item.ProductCount == 0)
            {
                _unitOfWork.Carts.Remove(item);
            }
            await Save();
        }
        public async Task CartPlusOneProduct(Guid cartId)
        {
            var item = await _unitOfWork.Carts.GetByIdAsync(cartId);
            item.ProductCount++;
            await Save();
        }
        public async Task ClearCart(Guid clientId)
        {
            var cartsDTO = await GetCarts(clientId);
            var carts = _mapper.Map<IEnumerable<Cart>>(cartsDTO);
            _unitOfWork.Carts.RemoveRange(carts.ToList());
            await Save();
        }
        public async Task RemoveProductInCart(Guid clientId, Guid productId)
        {
            var cartDTO = await _unitOfWork.Carts.GetCartByClientIdAndProductId(clientId, productId);
            var cart = _mapper.Map<Cart>(cartDTO);
            _unitOfWork.Carts.Remove(cart);
            await Save(); 
        }
        public async Task Update(CartDTO cartDTO)
        {
            var cart = _mapper.Map<Cart>(cartDTO);
            _unitOfWork.Carts.Update(cart);
            await Save();
        }
        private async Task Save()
        {
            await _unitOfWork.Carts.SaveAsync();
        }
    }
}
