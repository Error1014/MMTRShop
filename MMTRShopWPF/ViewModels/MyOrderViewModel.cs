using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.ViewModels
{
    public class MyOrderViewModel : BaseViewModel
    {
        private OrderService OrderService = new OrderService();
        private OrderContentService OrderContentService = new OrderContentService();
        private List<Order> orders = null;
        public List<Order> Orders
        {
            get
            {
                if (orders == null)
                {
                    Orders = OrderService.GetOrderClient(AccountManager.Client);
                }
                return orders;
            }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private List<OrderContent> orderContents = null;
        public List<OrderContent> OrderContents
        {
            get
            {
                if (orderContents == null)
                {
                    OrderContents = OrderContentService.GetOrderContentNoСompleted(Orders);
                }
                return orderContents;
            }
            set
            {
                orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
            }
        }


    }


}
