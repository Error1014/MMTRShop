using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.ViewModels
{
    public class MyHistoryViewModel:BaseViewModel
    {
        private OrderContentService OrderContentService = new OrderContentService();
        public MyHistoryViewModel()
        {
            OrderContents = OrderContentService.GetCancelledOrder();
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
