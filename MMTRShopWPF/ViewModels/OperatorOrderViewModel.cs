using MMTRShopWPF.Commands;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class OperatorOrderViewModel : BaseViewModel
    {
        private OrderService OrderService = new OrderService(new UnitOfWork(new ShopContext()));
        private ClientService ClientService = new ClientService(new UnitOfWork(new ShopContext()));
        private StatusService StatusService = new StatusService(new UnitOfWork(new ShopContext()));
        private OrderContentService OrderContentService = new OrderContentService(new UnitOfWork(new ShopContext()));

        private Order selectedOrder;
        public Order SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
                NavigarionManager.MainFrame.Content = new OrderInfoPage(selectedOrder);
            }
        }



        private ObservableCollection<Order> orders;
        public ObservableCollection<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }

        private ICommand getOrders;
        public ICommand GetOrders
        {
            get
            {
                if (getOrders == null) getOrders = new LoadedOperatorOrderVMCommand(this);
                return getOrders;
            }
        }

    }
}
