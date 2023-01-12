using MMTRShopWPF.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MMTRShopWPF.View.Pages;

namespace MMTRShopWPF.Service
{
    public class KorzinaViewModel : BaseViewModel
    {
        private KorzinaPage page;
        public KorzinaViewModel(KorzinaPage page)
        {
            this.page=page;
            Cart = UnitOfWork.Carts.GetKorzineByIdClient(AccountManager.Client.Id);
            Products = Cart.Join(UnitOfWork.Products.GetAll(),
            k => k.ProductId,
            p => p.Id,(k,p)=>new { k,p}).Select(x=>x.p).ToList();

        }
        private List<Cart> cart;
        public List<Cart> Cart
        {
            get
            {
                return cart;
            }
            set
            {
                cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }

        private List<Product> products;
        public List<Product> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public ICommand ProductMinus
        {
            get
            {
                return new Commands((obj) =>
                {
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    if (item.ProductCount>0)
                    {
                        item.ProductCount--;
                    }
                    if (item.ProductCount==0)
                    {
                        UnitOfWork.Carts.Remove(item);
                    }
                    UnitOfWork.Carts.Save();
                    page.UpdateDataContext();
                });
            }
        }
        public ICommand ProductPlus
        {
            get
            {
                return new Commands((obj) =>
                {
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    item.ProductCount++;

                    UnitOfWork.Carts.Save();
                    page.UpdateDataContext();
                });
            }
        }
        public ICommand ProductRemove
        {
            get
            {
                return new Commands((obj) =>
                {
                    System.Guid id = System.Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Carts.GetById(id);
                    UnitOfWork.Carts.Remove(item);

                    UnitOfWork.Carts.Save();
                    page.UpdateDataContext();
                });
            }
        }
    }
}
