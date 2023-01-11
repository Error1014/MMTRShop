using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Cart : BaseEntity<Guid>
    {
        
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }

        public virtual Client Client { get; set; }

        public Cart()
        {

        }
        public Cart(Guid clientId, Guid productId, int count)
        {
            ClientId = clientId;
            ProductId = productId;
            ProductCount = count;
        }
    }
}
