using System;
using System.Collections.ObjectModel;

namespace MMTRShopWPF.Service.Services
{
    public  class BankCardService: BaseService
    {
        public static ObservableCollection<int> GetAllMonth()
        {
            ObservableCollection<int> months = new ObservableCollection<int>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(i);
            }
            return months;
        }
        public static ObservableCollection<int> GetYear(int quantityYear)
        {
            ObservableCollection<int> year = new ObservableCollection<int>();
            DateTime dateTime = DateTime.Now;
            for (int i = dateTime.Year; i < dateTime.Year + quantityYear; i++)
            {
                year.Add(i);
            }
            return year;
        }
    }
}
