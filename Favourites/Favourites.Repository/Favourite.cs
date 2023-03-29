using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Favourites.Repository
{
    public class Favourite : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public Favourite()
        {
        }
        public Favourite(Guid clientId, Guid productId)
        {
            ClientId = clientId;
            ProductId = productId;
        }
    }
}
