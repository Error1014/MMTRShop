using Shop.Infrastructure.Repository;

namespace Orders.Repository.Entities
{
    public class Status : BaseEntity<int>
    {
        public string Title { get; set; }
    }
}
