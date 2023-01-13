﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace MMTRShopWPF.Service.Services
{
    public class FavouritesViewModel:BaseViewModel 
    {
        FavouritesPage page;
        public FavouritesViewModel(FavouritesPage page)
        {
            this.page = page;
            Favorites = FavouritesService.GetFavourites();
            Products = FavouritesService.GetProducts();

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
                    FavouritesService.RemoveFavouritById(id);
                    page.UpdateDataContext();

                });
            }
        }
    }
    
}