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
    public class ClickLikeCommand:BaseCommand<InfoProductViewModel>
    {
        private FavouritesService FavouritesService = new FavouritesService(new UnitOfWork(new ShopContext()));
        public ClickLikeCommand(InfoProductViewModel infoProductViewModel) : base(infoProductViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            if (AccountManager.Client == null)
            {
                ClientNullMessageShow();
            }
            else
            {
                if (viewModel.IsLikePath == "/Resources/NoLike.png")
                {
                    SetLike();
                }
                else
                {
                    RemoveLike();
                }
            }
        }
        private void ClientNullMessageShow()
        {
            MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
            MainWindow.MainWindowFrame.Content = new AutorizationPage();
        }
        private void SetLike()
        {
            viewModel.IsLikePath = "/Resources/Like.png";
            viewModel.Favourit = new Favourites(AccountManager.Client.Id, viewModel.Product.Id);
            FavouritesService.AddFavourite(viewModel.Favourit);

        }
        private void RemoveLike()
        {
            viewModel.IsLikePath = "/Resources/NoLike.png";
            FavouritesService.RemoveFavourite(viewModel.Favourit);
            viewModel.Favourit = new Favourites();
        }
    }
}
