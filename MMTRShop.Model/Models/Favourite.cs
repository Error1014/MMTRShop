using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.Models
{
    public class Favourite:BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public Favourite()
        {
        }
        public Favourite(Guid clientId,Guid productId)
        {
            ClientId = clientId;
            ProductId = productId;
        }
    }
}
