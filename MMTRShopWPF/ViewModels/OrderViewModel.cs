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
using MMTRShopWPF.ViewModels;
using MMTRShopWPF.Service.Services;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.ViewModels
{
    public class OrderViewModel:BaseViewModel
    {
        public OrderViewModel()
        {
            BankCardVM = new BankCardViewModel();
            BlockBankCardOpacity = 1;
            IsPayNow = true;
            Orders = OrderService.GetOrders();
            carts = OrderService.GetCart();
        }

        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
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
                return new Commands((obj) =>
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
                return new Commands((obj) =>
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
                return new Commands((obj) =>
                {
                    if (CheckAll())
                    {
                        Status status = UnitOfWork.Status.SetStatusPlaced();
                        Order = OrderService.SetOrder(Order.Address, IsPayNow, status);
                        OrderService.CreateOrder(Order);
                        OrderService.CreateOrderContent(Order);
                        OrderService.ClearCart(carts);
                        NavigarionManager.MainFrame.Content = new MyOrderPage();
                    }
                });
            }
        }

        #region Проверки введёных полей

        private bool CheckAll() 
        {
            if (IsPayNow)
            {
                if (OrderService.CheckWrittenRequisitesBankCard(BankCardVM.BankCard))
                {
                    if (!OrderService.CheckCorrectnessRequisitesBankCard(BankCardVM.BankCard))
                    {
                        MessageBox.Show("Вы ввели некоректные данные");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Вы ввели не все данные карты");
                    return false;
                }
            }
            if (!OrderService.CheckAddress(Order.Address))
            {
                MessageBox.Show("Вы не указали адрес");
                return false;
            }
            return true;
        }
        #endregion

    }
}
