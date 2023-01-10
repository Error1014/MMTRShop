using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Cart
    {
        [Key()]
        public Guid Id2 { get; set; }

        public Guid UserId2 { get; set; }
        public Guid ProductId2 { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }

        public virtual User User { get; set; }

        public Cart()
        {

        }
        public Cart(Guid userID, Guid productId, int count)
        {
            UserId2 = userID;
            ProductId2 = productId;
            ProductCount = count;
        }
    }
}
