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
    public class LoadedOperatorOrderVMCommand : BaseCommand<OperatorOrderViewModel>
    {
        private OrderService OrderService = new OrderService(new UnitOfWork(new ShopContext()));
        public LoadedOperatorOrderVMCommand(OperatorOrderViewModel vm) : base(vm)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.Orders = OrderService.GetOrders();
        }
    }
}
