using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Commands
{
    public class LoadedFavouritesVMCommand:BaseCommand<FavouritesViewModel>
    {
        FavouritesService FavouritesService = new FavouritesService(new UnitOfWork(new ShopContext()));
        public LoadedFavouritesVMCommand(FavouritesViewModel favouritesViewModel) : base(favouritesViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
{
            viewModel.Favorites = FavouritesService.GetFavourites();
        }

    }
}
