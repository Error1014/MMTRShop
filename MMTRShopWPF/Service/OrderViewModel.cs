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
                    if (IsPayNow)
                    {
                        if (CheckWrittenRequisitesBankCard())
                        {
                            if (!CheckCorrectnessRequisitesBankCard())
                            {
                                MessageBox.Show("Вы ввели некоректные данные");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Вы ввели не все данные карты");
                            return;
                        }
                    }
                    if (!CheckAddress())
                    {
                        MessageBox.Show("Вы не указали адрес");
                        return;
                    }
                    //Оформление заказа
                });
            }
        }

        #region Проверки введёных полей
        private bool CheckWrittenRequisitesBankCard()
        {
            if (String.IsNullOrEmpty(BankCardVM.BankCard.Number)
                || String.IsNullOrEmpty(BankCardVM.BankCard.Name)
                || String.IsNullOrEmpty(BankCardVM.BankCard.Code)
                || BankCardVM.BankCard.Mont == 0
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
