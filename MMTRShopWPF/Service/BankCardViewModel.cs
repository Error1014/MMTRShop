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


    }
}
