using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class AutorizationUserCommand : MyCommand<AutorizationViewModel>
    {
        private AutorizationService AutorizationService = new AutorizationService();
        public AutorizationUserCommand(AutorizationViewModel autorizationViewModel) : base(autorizationViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            AutorizationViewModel autorizationViewModel = viewModel;
            autorizationViewModel.Message = AutorizationService.CheckCorrectLoginPassword(autorizationViewModel.User.Login, autorizationViewModel.User.Password);
            if (!autorizationViewModel.Message.IsError())
            {
                Guid id = AutorizationService.GetUserId(autorizationViewModel.User.Login, autorizationViewModel.User.Password);
                MainWindow.MainWindowFrame.Content = new MainPage(id);
            }
        }
    }
}
