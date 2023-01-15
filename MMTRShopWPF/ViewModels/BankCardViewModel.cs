﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.ViewModels;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.ViewModels
{
    public class BankCardViewModel : BaseViewModel
    {
        private int quantityYear = 6;
        public BankCardViewModel()
        {
            BankCard = new BankCard();
            MonthItems = BankCardService.GetAllMonth();
            YearItems = BankCardService.GetYear(quantityYear);
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
