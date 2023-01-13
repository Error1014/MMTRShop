using MMTRShopWPF.Model;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.Service
{
    public class BankCardViewModel : BaseViewModel
    {
        public BankCardViewModel()
        {
            BankCard = new BankCard();
            BlockBankCardOpacity = 1;
            IsPayNow = true;
            for (int i = 1; i <= 12; i++)
            {
                MonthItems.Add(i);
            }
            DateTime dateTime = DateTime.Now;
            for (int i = dateTime.Year; i < dateTime.Year+6; i++)
            {
                YearItems.Add(i);
            }
        }

        private BankCard bankCard;
        public BankCard BankCard
        {
            get { return bankCard; }
            set
            {
                bankCard = value;
                OnPropertyChanged(nameof(BankCard));
            }
        }
        #region Списки месяц и год
        private ObservableCollection<int> monthItems = new ObservableCollection<int>();
        public ObservableCollection<int> MonthItems
        {
            get { return monthItems; }
            set
            {
                monthItems = value;
                OnPropertyChanged(nameof(MonthItems));
            }
        }

        private ObservableCollection<int> yearItems = new ObservableCollection<int>();
        public ObservableCollection<int> YearItems
        {
            get { return yearItems; }
            set
            {
                yearItems = value;
                OnPropertyChanged(nameof(YearItems));
            }
        }
        #endregion


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
                            if (CheckCorrectnessRequisitesBankCard())
                            {
                                MessageBox.Show("Всё гуд");
                            }
                            else
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
                    else
                    {
                        MessageBox.Show("Всё гуд");
                    }
                });
            }
        }

        private bool CheckWrittenRequisitesBankCard()
        {
            if (String.IsNullOrEmpty(BankCard.Number)
                || String.IsNullOrEmpty(BankCard.Name)
                || String.IsNullOrEmpty(BankCard.Code)
                || BankCard.Mont == 0 
                || BankCard.Year == 0) return false;
            else return true;
            
            
        }
        private bool CheckCorrectnessRequisitesBankCard()
        {
            //В дальнейшем будет реализовано
            return true;
        }


    }
}
