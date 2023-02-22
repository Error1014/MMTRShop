using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class OrderDTO
    {
        public Guid ClientId { get; set; }
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public bool IsPaid { get; set; }
        public int StatusId { get; set; }
    }
}
