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
    internal class SaveAccountSettingsCommand : BaseCommand<AccountViewModel>
    {
        private AccountService AccountService = new AccountService(new UnitOfWork(new ShopContext()));
        public SaveAccountSettingsCommand(AccountViewModel vm) : base(vm)
        {

        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityEditButton = true;
            User user = AccountService.GetUser();
            Client client = AccountService.GetClient();
            user.LastName = viewModel.LastName;
            user.FirstName = viewModel.FirstName;
            user.Patronymic = viewModel.Patronymic; 
            client.Email = viewModel.Email;
            client.Phone = viewModel.Phone;
            client.Address = viewModel.Address;
            AccountService.Save();
        }
    }
}
