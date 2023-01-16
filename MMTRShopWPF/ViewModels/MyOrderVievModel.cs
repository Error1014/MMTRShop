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
    public class MyOrderVievModel:BaseViewModel
    {
        public MyOrderVievModel()
        {
            Orders = MyOrderService.GetOrderClient(AccountManager.Client);

            OrderContents = MyOrderService.GetOrderContent(Orders);

        }
        private List<Order> orders;
        public List<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Order));
            }
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


    }

    
}
