using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class RegistrationUserCommand:BaseCommand<AutorizationViewModel>
    {
        private AutorizationService AutorizationService = new AutorizationService(new UnitOfWork(new ShopContext()));
        public RegistrationUserCommand(AutorizationViewModel autorizationViewModel) : base(autorizationViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.Message = AutorizationService.Registration(viewModel.User, viewModel.Password2);
            if (!viewModel.Message.IsError())
            {
                viewModel.Password2 = "";
                viewModel.User = new User();
                viewModel.IsRegistration = !viewModel.IsRegistration;
            }
        }
    }
}
