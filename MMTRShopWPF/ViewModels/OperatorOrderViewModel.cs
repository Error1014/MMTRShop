using MMTRShopWPF.Commands;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
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
        private OrderService OrderService = new OrderService();
        private ClientService ClientService = new ClientService();
        private StatusService StatusService = new StatusService();
        private OrderContentService OrderContentService = new OrderContentService();

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
