using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Repository.Entities
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
