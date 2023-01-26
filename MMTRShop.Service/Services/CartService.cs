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
        public List<Cart> GetCart()
        {
            return  _unitOfWork.Carts.GetCartByClient(AccountManager.Client).ToList();
        }


        public void AddProductInCart(Product product)
        {
            var myKorzine = _unitOfWork.Carts.GetCartByClient(AccountManager.Client).ToList();
            bool isNew = true;
            for (int i = 0; i < myKorzine.Count; i++)
            {
                if (myKorzine[i].ProductId == product.Id)
                {
                    isNew = false;
                    myKorzine[i].ProductCount++;
                }
            }
            if (isNew)
            {
                _unitOfWork.Carts.Add(new Cart(AccountManager.Client.Id, product.Id, 1));
            }
            _unitOfWork.Carts.Save();
        }
        public void CartMinusOneProduct(Guid id)
        {
            var item = _unitOfWork.Carts.GetById(id);
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
        public void CartPlusOneProduct(Guid id)
        {
            var item = _unitOfWork.Carts.GetById(id);
            item.ProductCount++;
            _unitOfWork.Carts.Save();
        }
        public void CartRemoveProduct(Guid id)
        {
            var item = _unitOfWork.Carts.GetById(id);
            _unitOfWork.Carts.Remove(item);
            _unitOfWork.Carts.Save();
        }

        public void ClearCart()
        {
            var carts = GetCart();
            _unitOfWork.Carts.RemoveRange(carts);
            _unitOfWork.Carts.Save();
        }
    }
}
