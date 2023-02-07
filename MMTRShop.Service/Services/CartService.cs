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
        public async Task<IEnumerable<Cart>> GetCart()
        {
            return await _unitOfWork.Carts.GetCartByClient(AccountManager.Client);
        }


        public async Task AddProductInCart(Product product)
        {
            var myKorzine = await _unitOfWork.Carts.GetCartByClient(AccountManager.Client);
            var korzine = myKorzine.ToList();
            bool isNew = true;
            for (int i = 0; i < korzine.Count; i++)
            {
                if (korzine[i].ProductId == product.Id)
                {
                    isNew = false;
                    korzine[i].ProductCount++;
                }
            }
            if (isNew)
            {
                _unitOfWork.Carts.Add(new Cart(AccountManager.Client.Id, product.Id, 1));
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
                CartRemoveProduct(id);
            }
            await _unitOfWork.Carts.SaveAsync();
        }
        public async Task CartPlusOneProduct(Guid id)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(id);
            item.ProductCount++;
            await _unitOfWork.Carts.SaveAsync();
        }
        public async Task CartRemoveProduct(Guid id)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(id);
            _unitOfWork.Carts.Remove(item);
            await _unitOfWork.Carts.SaveAsync();
        }

        public async Task ClearCart()
        {
            var carts =await GetCart();
            _unitOfWork.Carts.RemoveRange(carts);
            await _unitOfWork.Carts.SaveAsync();
        }
    }
}
