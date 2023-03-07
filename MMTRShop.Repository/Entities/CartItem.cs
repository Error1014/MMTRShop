using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
{
    public class CartItem:BaseEntity<Guid>
    {
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }
    }
}
