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
    public class CancelEditCommand : BaseCommand<AccountViewModel>
    {
        private AccountService AccountService = new AccountService(new UnitOfWork(new ShopContext()));
        public CancelEditCommand(AccountViewModel accountViewModel) : base(accountViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityEditButton = true;
            viewModel.User = AccountService.GetUser();
            viewModel.Client = AccountService.GetClient();
        }
    }
}
