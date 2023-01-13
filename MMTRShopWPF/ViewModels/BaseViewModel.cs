﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repository;
using System.ComponentModel;



namespace MMTRShopWPF.Service.Services
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected UnitOfWork UnitOfWork = new UnitOfWork(new ShopContext());
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}