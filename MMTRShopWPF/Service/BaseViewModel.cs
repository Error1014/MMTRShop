using MMTRShopWPF.Model;
using MMTRShopWPF.Repositories;
using MMTRShopWPF.Repositories.Repository;
using System.ComponentModel;

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
