using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class OpenRegistrationPanelCommand : BaseCommand<AutorizationViewModel>
    {
        public OpenRegistrationPanelCommand(AutorizationViewModel autorizationViewModel) : base(autorizationViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.IsRegistration = !viewModel.IsRegistration;
        }
    }
}
