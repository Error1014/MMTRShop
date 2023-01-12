using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class FavouritesViewModel:BaseViewModel 
    {
        private FavouritesPage page;
        public FavouritesViewModel(Client client, FavouritesPage page)
        {
            user = client;
            this.page = page;
            Favorites = UnitOfWork.Favorites.GetFavouritesByIdUser(client.Id);//.GetKorzineByIDUser(user.Id);

            Products = Favorites.Join(UnitOfWork.Products.GetAll(),
            f => f.ProductId,
            p => p.Id, (f, p) => new { f, p }).Select(x => x.p).ToList();

        }
        private Client user;
        public Client User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                OnPropertyChanged(nameof(User));
            }
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
    }
    
}
