using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MMTRShopWPF.Commands
{
    public class NavigateCommand:BaseCommand<NavigationViewModel>
    {
        protected Page page;
        protected bool isCheckUser;
        private NavigationService NavigationService = new NavigationService();
        public NavigateCommand(NavigationViewModel navigationViewModel,Page page,bool isCheckUser) : base(navigationViewModel)
        {
            this.page = page;
            this.isCheckUser = isCheckUser;
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            if (isCheckUser)
            {
                viewModel.Message = NavigationService.CheckAutorisation();
                if (!viewModel.Message.IsError())
                {
                    NavigarionManager.MainFrame.Content = page;
                }
            }
            else
            {
                NavigarionManager.MainFrame.Content = page;
            }
        }
    }
}
