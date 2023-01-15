using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class Order : BaseEntity<Guid>
    {
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public bool IsPaid { get; set; }
        public Guid StatusId { get; set; }
        public virtual Status Status { get; set; }

        public Order()
        {

        }

        public Order(Client client, string address, bool isPaid, Guid statusId)
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
