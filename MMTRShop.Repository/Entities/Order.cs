using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
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


        public Order(Client client, string address, bool isPaid, int statusId)
        {
            ClientId = client.Id;
            Address = address;
            DateOrder = DateTime.Now;
            DateDelivery = DateOrder;
            IsPaid = isPaid;
            StatusId = statusId;
        }
    }
}
