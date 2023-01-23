using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using MMTRShopWPF.Service.Services;
using System;
using System.ComponentModel;



namespace MMTRShopWPF.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected UnitOfWork UnitOfWork = new UnitOfWork(new ShopContext());
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Message message = new Message();
        public Message Message
        {
            get { return message; }
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

    }
}
