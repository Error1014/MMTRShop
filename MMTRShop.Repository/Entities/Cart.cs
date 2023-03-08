using System;

namespace MMTRShop.Repository.Entities
{
    public class Cart : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int ProductCount { get; set; }


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
