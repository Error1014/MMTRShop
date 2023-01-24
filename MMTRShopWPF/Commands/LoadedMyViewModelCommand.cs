﻿using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class LoadedMyViewModelCommand: BaseCommand<MyOrderViewModel>
    {
        private OrderContentService OrderContentService = new OrderContentService();
        private OrderService OrderService = new OrderService();
        public LoadedMyViewModelCommand(MyOrderViewModel myOrderViewModel) : base(myOrderViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            viewModel.Orders = OrderService.GetOrderClient(AccountManager.Client);
            viewModel.OrderContents = OrderContentService.GetOrderContentNoСompleted(viewModel.Orders);

        }
    }
}