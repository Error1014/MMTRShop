using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.Service;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Commands;
using MMTRShopWPF.Service.Services;
using System.Collections.ObjectModel;
using System.Windows.Documents;
using System.Net;

namespace MMTRShopWPF.Commands
{
    public class OrderViewModel : BaseViewModel
    {
        private CartService CartService = new CartService();
        private OrderService OrderService = new OrderService();
        private OrderContentService OrderContentService = new OrderContentService();
        private StatusService StatusService = new StatusService();

        public OrderViewModel()
        {
            BankCardVM = new BankCardViewModel();
            BlockBankCardOpacity = 1;
            IsPayNow = true;
            carts = CartService.GetCart();
            Status = StatusService.GetStatusWaitingPlaced();
        }



        private Order order = new Order();
        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
            }
        }
        private Status status;
        public Status Status
        {
            get { return status; }
            set
            {
                status = value;
                Order.StatusId = value.Id;
                OnPropertyChanged(nameof(Status));
            }
        }
        private BankCardViewModel bankCardVM;
        public BankCardViewModel BankCardVM
        {
            get { return bankCardVM; }
            set
            {
                bankCardVM = value;
                OnPropertyChanged(nameof(BankCardVM));
            }
        }

        private List<OrderContent> cartOrders = new List<OrderContent>();
        private List<Cart> carts = new List<Cart>();

        #region Способ оплаты
        private bool isPayNow;
        public bool IsPayNow
        {
            get { return isPayNow; }
            set
            {
                isPayNow = value;
                Order.IsPaid = value;
                OnPropertyChanged(nameof(IsPayNow));
            }
        }
        private float blockBankCardOpacity;
        public float BlockBankCardOpacity
        {
            get { return blockBankCardOpacity; }
            set
            {
                blockBankCardOpacity = value;
                OnPropertyChanged(nameof(BlockBankCardOpacity));
            }
        }

        public ICommand PayLater
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    IsPayNow = false;
                    BlockBankCardOpacity = 0.5f;
                });
            }
        }

        public ICommand PayNow
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    IsPayNow = true;
                    BlockBankCardOpacity = 1f;
                });
            }
        }
        #endregion

        public ICommand PlaceAnOrder
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    if (CheckAll())
{
                        Order.DateOrder = DateTime.Now;
                        Order.DateDelivery = Order.DateOrder;
                        Order.ClientId = AccountManager.Client.Id;
                        OrderService.CreateOrder(Order);
                        OrderContentService.CreateOrderContent(Order);
                        CartService.ClearCart(carts);
                        NavigarionManager.MainFrame.Content = new MyOrderPage();
                    }
                });
            }
        }
        public ICommand CloseWin
        {
            get
            {
                return new BaseCommand((obj) =>
                {
                    Message = new Message();
                });
            }
        }

        #region Проверки введёных полей
        
        private bool CheckAll()
        {

            if (IsPayNow)
            {
                Message = OrderService.CheckWrittenRequisitesBankCard(BankCardVM.BankCard);
                if (Message.IsError()) return false;
                Message = OrderService.CheckCorrectnessRequisitesBankCard(BankCardVM.BankCard);
                if (Message.IsError()) return false;
            }
            Message = OrderService.CheckAddress(Order.Address);
            if (Message.IsError()) return false;
            return true;
        }
        #endregion

    }
}
