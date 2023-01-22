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
    public class RegistrationUserCommand:MyCommand<AutorizationViewModel>
    {
        private AutorizationService AutorizationService = new AutorizationService();
        public RegistrationUserCommand(AutorizationViewModel autorizationViewModel) : base(autorizationViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            AutorizationViewModel autorizationViewModel = viewModel;
            autorizationViewModel.Message = AutorizationService.Registration(autorizationViewModel.User, autorizationViewModel.Password2);
            if (!autorizationViewModel.Message.IsError())
            {
                autorizationViewModel.Password2 = "";
                autorizationViewModel.User = new User();
                autorizationViewModel.IsRegistration = !autorizationViewModel.IsRegistration;
            }
        }
    }
}
