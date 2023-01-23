using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Commands
{
    public class AddInCartCommand:BaseCommand<InfoProductViewModel>
    {
        CartService CartService = new CartService();
        public AddInCartCommand(InfoProductViewModel infoProductViewModel) : base(infoProductViewModel)
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
                CartService.AddProductInCart(viewModel.Product);
            }
        }
        private void ClientNullMessageShow()
        {
            MessageBox.Show("Для этого вам сперва необходимо войти в аккаутн");
            MainWindow.MainWindowFrame.Content = new AutorizationPage();
        }
    }
}
