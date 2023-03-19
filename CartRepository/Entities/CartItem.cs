using Shop.Infrastructure.Repository;
using System;

namespace CartMicroservice.Carts.Repository.Entities
{
    public class CartItem : BaseEntity<Guid>
    {
        public Guid CartId { get; set; }
        public virtual Cart Cart { get; set; }
        public Guid ProductId { get; set; }
        public int ProductCount { get; set; }


        public CartItem()
        {

        }
        public CartItem(Guid clientId, Guid productId, int count)
        {
            CartId = clientId;
            ProductId = productId;
            ProductCount = count;
        }
    }
}
