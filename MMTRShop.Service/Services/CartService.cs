﻿using AutoMapper;
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
        private readonly UserSession _userSession;
        public CartService(IUnitOfWork unitOfWork, IMapper mapper, UserSession userSession)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userSession = userSession;
        }
        private async Task<IEnumerable<CartItem>> GetCarts(FilterByClient filter)
        {
            return await _unitOfWork.CartItems.GetCarts(filter);
        }
        public async Task<IEnumerable<CartDTO>> GetCartsDTO(FilterByClient filter)
        {
            var carts = await GetCarts(filter);
            var result = _mapper.Map<IEnumerable<CartDTO>>(carts);
            return result;
        }
        public async Task<CartDTO> GetCart(Guid id)
        {
            var cart = await _unitOfWork.CartItems.GetByIdAsync(id);
            var result = _mapper.Map<CartDTO>(cart);
            return result;
        }
        public async Task<CartDTO> GetCartByClientIdAndProductId(Guid clientId,Guid productId)
        {
            var cart = await _unitOfWork.CartItems.GetCartByClientIdAndProductId(clientId,productId);
            var result = _mapper.Map<CartDTO>(cart);
            return result;
        }
        public async Task AddProductInCart(CartDTO cartDTO)
        {
            var myKorzine = await _unitOfWork.CartItems.GetCartsByClient(cartDTO.ClientId);
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
                _unitOfWork.CartItems.Add(new CartItem(cartDTO.ClientId, cartDTO.ProductId, 1));
            }
            await Save();
        }
        public async Task CartMinusOneProduct(Guid id)
        {
            var item = await _unitOfWork.CartItems.GetByIdAsync(id);
            if (item.ProductCount > 0)
            {
                item.ProductCount--;
            }
            if (item.ProductCount == 0)
            {
                _unitOfWork.CartItems.Remove(item);
            }
            await Save();
        }
        public async Task CartPlusOneProduct(Guid cartId)
        {
            var item = await _unitOfWork.CartItems.GetByIdAsync(cartId);
            item.ProductCount++;
            await Save();
        }
        public async Task ClearCart()
        {
            var cartsDTO = await _unitOfWork.CartItems.GetCartsByClient(_userSession.Id);
            var carts = _mapper.Map<IEnumerable<CartItem>>(cartsDTO);
            _unitOfWork.CartItems.RemoveRange(carts.ToList());
            await Save();
        }
        public async Task RemoveProductInCart(Guid productId)
        {
            var cartDTO = await _unitOfWork.CartItems.GetCartByClientIdAndProductId(_userSession.Id, productId);
            var cart = _mapper.Map<CartItem>(cartDTO);
            _unitOfWork.CartItems.Remove(cart);
            await Save(); 
        }
        public async Task Update(CartDTO cartDTO)
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
