﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class OperatorOrderViewModel:BaseViewModel
    {
        private OrderService OrderService = new OrderService();
        private ClientService ClientService = new ClientService();
        private StatusService StatusService = new StatusService();
        public OperatorOrderViewModel()
        {
            Orders = OrderService.GetOrders();
        }
        public OperatorOrderViewModel(Order order)
        {
            Order = order;
            Client = ClientService.GetClient(Order);
            Statuses = UnitOfWork.Status.GetAll().ToList();
            Status = StatusService.GetStatus(order);

        }
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
        private List<Status> statuses;
        public List<Status> Statuses
        {
            get { return statuses; }
            set
            {
                statuses = value;
                OnPropertyChanged(nameof(Statuses));
            }
        }
        private Status status;
        public Status Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        private Order order;
        public Order Order
        {
            get { return order; }
            set
            {
                order = value;
                OnPropertyChanged(nameof(Order));
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
        private Client client;
        public Client Client
        {
            get { return client; }
            set
            {
                client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
        public ICommand Back
        {
            get
            {
                return new Commands((obj) =>
                {
                    NavigarionManager.MainFrame.Content = new OrdersPage();
                });
            }
        }
        public ICommand Save
        {
            get
            {
                return new Commands((obj) =>
                {
                    Order.StatusId = Status.Id;
                    OrderService.SaveOrder();
                    NavigarionManager.MainFrame.Content = new OrdersPage();
                });
            }
        }
        public ICommand ContactClient
        {
            get
            {
                return new Commands((obj) =>
                {
                });
            }
        }
    }
}
