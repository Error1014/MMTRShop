using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.ViewModels
{
    public class BankCardViewModel : BaseViewModel
    {
        private int quantityYear = 6;
        BankCardService BankCardService = new BankCardService(new UnitOfWork(new ShopContext()));

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
        private ObservableCollection<int> monthItems;
        public ObservableCollection<int> MonthItems
        {
            get 
            {
                if (monthItems == null)
                {
                    MonthItems = BankCardService.GetAllMonth();
                }
                return monthItems; 
            }
            set
            {
                monthItems = value;
                OnPropertyChanged(nameof(MonthItems));
            }
        }

        private ObservableCollection<int> yearItems;
        public ObservableCollection<int> YearItems
        {
            get
            {
                if (yearItems == null)
                {
                    YearItems = BankCardService.GetYear(quantityYear);
                }
                return yearItems;
            }
            set
            {
                yearItems = value;
                OnPropertyChanged(nameof(YearItems));
            }
        }
        #endregion


    }
}
