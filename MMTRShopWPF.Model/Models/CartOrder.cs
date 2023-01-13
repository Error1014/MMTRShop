using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class CartOrder:BaseEntity<Guid>
    {
        public Guid CartId { get; set; }
        public Guid OrderId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Order Order { get; set; }

        public CartOrder()
        {

        }
        public CartOrder(Guid cartID, Guid orderId)
        {
            CartId = cartID;
            OrderId = orderId;
        }
    }
}
