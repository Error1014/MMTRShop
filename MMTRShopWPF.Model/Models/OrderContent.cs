using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class OrderContent:BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int CountProduct { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }

        public OrderContent()
        {

        }

        public OrderContent(Order order, Cart cart)
        {
            OrderId = OrderId;
            ProductId = cart.ProductId;
            CountProduct = cart.ProductCount;
        }

    }   
}
