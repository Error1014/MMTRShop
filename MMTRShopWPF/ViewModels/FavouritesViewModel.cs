using MMTRShopWPF.Commands;
using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class FavouritesViewModel:BaseViewModel 
    {
        FavouritesPage page;
        private FavouritesService FavouritesService = new FavouritesService();
        public FavouritesViewModel(FavouritesPage page)
        {
            this.page = page;
            Favorites = FavouritesService.GetFavourites();

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

        private ICommand removeFavourit;
        public ICommand RemoveFavourit
        {
            get
            {
                if (removeFavourit == null) removeFavourit = new RemoveFavouritCommand(this);
                return removeFavourit;
            }
        }
    }
    
}
