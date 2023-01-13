using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace MMTRShopWPF.Service
{
    public class OrderViewModel:BaseViewModel
    {
        public OrderViewModel()
        {
            BankCardVM = new BankCardViewModel();
            BlockBankCardOpacity = 1;
            IsPayNow = true;
            
        }

        private Order order;
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

        private List<CartOrder> cartOrders = new List<CartOrder>();
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
                        Order order = new Order(Order.Address, IsPayNow, status.Id);
                        UnitOfWork.Orders.Add(order);//создаём заказ
                        UnitOfWork.Orders.Save();

                        carts = UnitOfWork.Carts.GetCartByIdClient(AccountManager.Client.Id);
                        foreach (var item in carts)
                        {
                            cartOrders.Add(new CartOrder(item.Id, order.Id));
                        }
                        UnitOfWork.CartOrders.AddRange(cartOrders);// заполняем дополнительную таблицу 
                        UnitOfWork.CartOrders.Save();

                        UnitOfWork.Carts.RemoveRange(carts);//чистим корзину
                        UnitOfWork.Carts.Save();

                    }
                });
            }
        }

        #region Проверки введёных полей

        private bool CheckAll() 
        {
            if (IsPayNow)
            {
                if (CheckWrittenRequisitesBankCard())
                {
                    if (!CheckCorrectnessRequisitesBankCard())
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
            if (!CheckAddress())
            {
                MessageBox.Show("Вы не указали адрес");
                return false;
            }
            return true;
        }
        private bool CheckWrittenRequisitesBankCard()
        {
            if (String.IsNullOrEmpty(BankCardVM.BankCard.Number)
                || String.IsNullOrEmpty(BankCardVM.BankCard.Name)
                || String.IsNullOrEmpty(BankCardVM.BankCard.Code)
                || BankCardVM.BankCard.Month == 0
                || BankCardVM.BankCard.Year == 0) return false;
            else return true;


        }
        private bool CheckCorrectnessRequisitesBankCard()
        {
            //В дальнейшем будет реализовано
            return true;
        }

        private bool CheckAddress()
        {
            return !String.IsNullOrEmpty(Order.Address);
        }
        #endregion

    }
}
