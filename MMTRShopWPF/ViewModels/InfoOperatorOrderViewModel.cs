using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class InfoOperatorOrderViewModel:BaseViewModel
    {
        private OrderService OrderService = new OrderService(new UnitOfWork(new ShopContext()));
        private ClientService ClientService = new ClientService(new UnitOfWork(new ShopContext()));
        private StatusService StatusService = new StatusService(new UnitOfWork(new ShopContext()));
        private OrderContentService OrderContentService = new OrderContentService(new UnitOfWork(new ShopContext()));
        public InfoOperatorOrderViewModel(Order order)
        {
            Order = OrderService.GetOrder(order);
            Client = ClientService.GetClient(Order);
            Statuses = StatusService.GetAll();
            Status = StatusService.GetStatus(order);
            OrderContents = OrderContentService.GetOrderContents(order);

        }
        private List<OrderContent> orderContents;
        public List<OrderContent> OrderContents
        {
            get { return orderContents; }
            set
            {
                orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
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
                Order.StatusId = status.Id;
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
