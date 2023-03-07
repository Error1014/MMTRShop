using System;

namespace MMTRShop.Repository.Entities
{
    public class Cart : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }


        public Cart(Guid id)
        {
            Id = id;
        }
    }
}
