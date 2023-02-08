using MMTRShop.Model;
using MMTRShop.Model.Models;
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
    public class CartService: ICartService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Cart>> GetCart(Guid clientId)
        {
            return await _unitOfWork.Carts.GetCartByClient(clientId);
        }


        public async Task AddProductInCart(Guid productId)
        {
            var myKorzine = await _unitOfWork.Carts.GetCartByClient(AccountManager.Client.Id);
            var korzine = myKorzine.ToList();
            bool isNew = true;
            for (int i = 0; i < korzine.Count; i++)
            {
                if (korzine[i].ProductId == productId)
                {
                    isNew = false;
                    korzine[i].ProductCount++;
                }
            }
            if (isNew)
            {
                _unitOfWork.Carts.Add(new Cart(AccountManager.Client.Id, productId, 1));
            }
            await _unitOfWork.Carts.SaveAsync();
        }
        public async Task CartMinusOneProduct(Guid id)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(id);
            if (item.ProductCount > 0)
            {
                item.ProductCount--;
            }
            if (item.ProductCount == 0)
            {
                _unitOfWork.Carts.Remove(item);
            }
            await _unitOfWork.Carts.SaveAsync();
        }
        public async Task CartPlusOneProduct(Guid cartId)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(cartId);
            item.ProductCount++;
            await _unitOfWork.Carts.SaveAsync();
        }

        public async Task ClearCart(Guid clientId)
        {
            var carts = await GetCart(clientId);
            _unitOfWork.Carts.RemoveRange(carts);
            await _unitOfWork.Carts.SaveAsync();
        }
    }
}
