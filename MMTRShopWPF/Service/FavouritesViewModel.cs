using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MMTRShopWPF.Service
{
    public class FavouritesViewModel:BaseViewModel 
    {
        FavouritesPage page;
        public FavouritesViewModel(FavouritesPage page)
        {
            this.page = page; 
            Favorites = UnitOfWork.Favorites.GetFavouritesByIdUser(AccountManager.Client.Id);//.GetKorzineByIDUser(user.Id);

            Products = Favorites.Join(UnitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();

        }
        private List<Favourites> favorites;
        public List<Favourites> Favorites
        {
            get
            {
                return favorites;
            }
            set
            {
                favorites = value;
                OnPropertyChanged(nameof(Favorites));
            }
        }
        private Favourites favourit = new Favourites();
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
        public ICommand RemoveFavourit
        {
            get
            {
                return new Commands((obj) =>
                {
                    Guid id = Guid.Parse(obj.ToString());
                    var item = UnitOfWork.Favorites.GetById(id);
                    
                    UnitOfWork.Favorites.Remove(item);
                    UnitOfWork.Favorites.Save();
                    page.UpdateDataContext();

                });
            }
        }
        private void RemoveLike()
        {
            UnitOfWork.Favorites.Remove(favourit);
            UnitOfWork.Favorites.Save();
            favourit = new Favourites();
        }
    }
    
}
