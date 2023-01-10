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
        public int Id { get; set; }
        
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }

        public virtual User User { get; set; }

        public Cart()
        {

        }
        public Cart(int userID, int productId, int count)
        {
            UserId = userID;
            ProductId = productId;
            ProductCount = count;
        }
    }
}
