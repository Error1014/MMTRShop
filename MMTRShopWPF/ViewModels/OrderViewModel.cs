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
using System.Windows.Documents;
using System.Net;
using MMTRShopWPF.Commands;

namespace MMTRShopWPF.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        private CartService CartService = new CartService();
        private StatusService StatusService = new StatusService();

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
            get 
            {
                if (status==null)
                {
                    Status = StatusService.GetStatusWaitingPlaced();
                }
                return status; 
            }
            set
            {
                status = value;
                Order.StatusId = value.Id;
                OnPropertyChanged(nameof(Status));
            }
        }
        private BankCardViewModel bankCardVM = new BankCardViewModel();
        public BankCardViewModel BankCardVM
        {
            get 
            {
                return bankCardVM; 
            }
            set
            {
                bankCardVM = value;
                OnPropertyChanged(nameof(BankCardVM));
            }
        }

        private List<Cart> carts;
        public List<Cart> Carts
        {
            get 
            {
                if (carts ==null)
                {
                    Carts = CartService.GetCart().ToList();
                }
                return carts; 
            }
            set
            {
                carts = value;
                OnPropertyChanged(nameof(Carts));
            }
        }

        #region Способ оплаты
        private bool isPayNow = true;
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
        private float blockBankCardOpacity=1;
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

        private ICommand placeAnOrder;
        public ICommand PlaceAnOrder
        {
            get
            {
                if (placeAnOrder == null) placeAnOrder = new PlaceAnOrderCommand(this);
                return placeAnOrder;
            }
        }
        public ICommand CloseWin
        {
            get
            {
                return new Commands((obj) =>
                {
                    Message = new Message();
                });
            }
        }
    }
}
