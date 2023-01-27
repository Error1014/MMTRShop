using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class LoadedAccountVMCommand : BaseCommand<AccountViewModel>
    {
        private AccountService AccountService = new AccountService(new UnitOfWork(new ShopContext()));
        public LoadedAccountVMCommand(AccountViewModel accountViewModel) : base(accountViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.User = AccountService.GetUser();
            viewModel.Client = AccountService.GetClient();
        }
    }
}
