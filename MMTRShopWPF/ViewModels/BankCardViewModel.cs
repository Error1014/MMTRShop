using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.ViewModels
{
    public class BankCardViewModel : BaseViewModel
    {
        private int quantityYear = 6;
        BankCardService BankCardService = new BankCardService();
        public BankCardViewModel()
        {
            MonthItems = BankCardService.GetAllMonth();
            YearItems = BankCardService.GetYear(quantityYear);
        }

        private BankCard bankCard = new BankCard();
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

        private int selectedMonth;
        public int SelectedMonth
        {
            get { return selectedMonth; }
            set
            {
                selectedMonth = value;
                BankCard.Month = value;
                OnPropertyChanged(nameof(SelectedMonth));
            }
        }
        private int selectedYear;
        public int SelectedYear
        {
            get { return selectedYear; }
            set
            {
                selectedYear = value;
                BankCard.Year = value;
                OnPropertyChanged(nameof(SelectedYear));
            }
        }
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
