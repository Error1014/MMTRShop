﻿using MMTRShopWPF.Repositoryes;
using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
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