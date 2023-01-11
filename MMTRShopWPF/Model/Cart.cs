using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Cart
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }

        public virtual User User { get; set; }

        public Cart()
        {

        }
        public Cart(Guid userID, Guid productId, int count)
        {
            UserId = userID;
            ProductId = productId;
            ProductCount = count;
        }
    }
}
