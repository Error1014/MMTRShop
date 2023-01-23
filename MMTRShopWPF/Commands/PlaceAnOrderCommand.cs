using MMTRShopWPF.Model.Models;
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
    public class PlaceAnOrderCommand:BaseCommand<OrderViewModel>
    {
        private OrderService OrderService = new OrderService();
        private OrderContentService OrderContentService = new OrderContentService();
        private CartService CartService = new CartService();
        public PlaceAnOrderCommand(OrderViewModel orderViewModel) : base(orderViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            if (CheckAll())
            {
                viewModel.Order.DateOrder = DateTime.Now;
                viewModel.Order.DateDelivery = viewModel.Order.DateOrder;
                viewModel.Order.ClientId = AccountManager.Client.Id;
                OrderService.CreateOrder(viewModel.Order);
                OrderContentService.CreateOrderContent(viewModel.Order);
                CartService.ClearCart(viewModel.Carts);
                NavigarionManager.MainFrame.Content = new MyOrderPage();
            }
        }

        #region Проверки введёных полей

        private bool CheckAll()
        {

            if (viewModel.IsPayNow)
            {
                viewModel.Message = OrderService.CheckWrittenRequisitesBankCard(viewModel.BankCardVM.BankCard);
                if (viewModel.Message.IsError()) return false;
                viewModel.Message = OrderService.CheckCorrectnessRequisitesBankCard(viewModel.BankCardVM.BankCard);
                if (viewModel.Message.IsError()) return false;
            }
            viewModel.Message = OrderService.CheckAddress(viewModel.Order.Address);
            if (viewModel.Message.IsError()) return false;
            return true;
        }
        #endregion
    }
}
