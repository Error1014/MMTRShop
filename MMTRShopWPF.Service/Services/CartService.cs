using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service.Services
{
    public class CartService
    {
        UnitOfWork UnitOfWork { get; set; }
        public CartService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public List<Cart> GetCart()
        {
            return  UnitOfWork.Carts.GetCartByClient(AccountManager.Client).ToList();
        }


        public void AddProductInCart(Product product)
        {
            var myKorzine = UnitOfWork.Carts.GetCartByClient(AccountManager.Client).ToList();
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
                UnitOfWork.Carts.Add(new Cart(AccountManager.Client.Id, product.Id, 1));
            }
            UnitOfWork.Carts.Save();
        }
        public void CartMinusOneProduct(Guid id)
        {
            var item = UnitOfWork.Carts.GetById(id);
            if (item.ProductCount > 0)
            {
                item.ProductCount--;
            }
            if (item.ProductCount == 0)
            {
                CartRemoveProduct(id);
            }
            UnitOfWork.Carts.Save();
        }
        public void CartPlusOneProduct(Guid id)
        {
            var item = UnitOfWork.Carts.GetById(id);
            item.ProductCount++;
            UnitOfWork.Carts.Save();
        }
        public void CartRemoveProduct(Guid id)
        {
            var item = UnitOfWork.Carts.GetById(id);
            UnitOfWork.Carts.Remove(item);
            UnitOfWork.Carts.Save();
        }

        public void ClearCart(List<Cart> carts)
        {
            UnitOfWork.Carts.RemoveRange(carts);
            UnitOfWork.Carts.Save();
        }
    }
}
