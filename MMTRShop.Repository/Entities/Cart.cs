using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
{
    public class Cart : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }

        public Cart()
        {

        }
        public Cart(Guid id)
        {
            ClientId = id;
        }
    }
}
