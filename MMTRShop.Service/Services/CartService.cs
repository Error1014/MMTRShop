using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class CartService
    {
        private readonly UnitOfWork _unitOfWork;
        public CartService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Cart>> GetCart()
        {
            return await _unitOfWork.Carts.GetCartByClient(AccountManager.Client);
        }


        public async void AddProductInCart(Product product)
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
            _unitOfWork.Carts.Save();
        }
        public async void CartMinusOneProduct(Guid id)
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
            _unitOfWork.Carts.Save();
        }
        public async void CartPlusOneProduct(Guid id)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(id);
            item.ProductCount++;
            _unitOfWork.Carts.Save();
        }
        public async void CartRemoveProduct(Guid id)
        {
            var item =await _unitOfWork.Carts.GetByIdAsync(id);
            _unitOfWork.Carts.Remove(item);
            _unitOfWork.Carts.Save();
        }

        public async void ClearCart()
        {
            var carts =await GetCart();
            _unitOfWork.Carts.RemoveRange(carts);
            _unitOfWork.Carts.Save();
        }
    }
}
