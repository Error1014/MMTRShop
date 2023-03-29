using Shop.Infrastructure.Repository;

namespace Orders.Repository.Entities
{
    public class Order : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public bool IsPaid { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }

        public Order()
        {

        }


        public Order(Guid clientId, string address, bool isPaid, int statusId)
        {
            ClientId = clientId;
            Address = address;
            DateOrder = DateTime.Now;
            DateDelivery = DateOrder;
            IsPaid = isPaid;
            StatusId = statusId;
        }
    }
}
