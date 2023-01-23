using MMTRShopWPF.Commands;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MMTRShopWPF.ViewModels
{
    public class MyOrderViewModel : BaseViewModel
    {
        private List<Order> orders = null;
        public List<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private List<OrderContent> orderContents = null;
        public List<OrderContent> OrderContents
        {
            get { return orderContents; }
            set
            {
                orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
            }
        }
        private ICommand getOrderContentsNoСompleted;
        public ICommand GetOrderContentsNoСompleted
        {
            get
            {
                if (getOrderContentsNoСompleted == null) getOrderContentsNoСompleted = new LoadedMyViewModelCommand(this);
                return getOrderContentsNoСompleted;
            }
        }


    }


}
