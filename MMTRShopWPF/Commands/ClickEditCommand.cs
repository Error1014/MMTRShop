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
using System.Windows;

namespace MMTRShopWPF.Commands
{
    public class ClickEditCommand : BaseCommand<AccountViewModel>
    {
        CartService CartService = new CartService(new UnitOfWork(new ShopContext()));
        public ClickEditCommand(AccountViewModel vm) : base(vm)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.VisibilityEditButton = false;
            viewModel.VisibilitySaveAndCancelButton = true;
        }
    }
}
