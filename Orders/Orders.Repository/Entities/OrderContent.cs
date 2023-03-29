using Shop.Infrastructure.Repository;

namespace Orders.Repository.Entities
{
    public class OrderContent : BaseEntity<Guid>
    {
        public Guid OrderId { get; set; }

        public Guid ProductId { get; set; }

        public int CountProduct { get; set; }

        public virtual Order Order { get; set; }

        public OrderContent()
        {

        }

        public OrderContent(Order order, Guid productId, int productCount)
        {
            OrderId = order.Id;
            ProductId = productId;
            CountProduct = productCount;
        }

    }
}
