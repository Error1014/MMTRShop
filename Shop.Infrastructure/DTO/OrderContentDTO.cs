using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class OrderContentDTO
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int CountProduct { get; set; }
    }
}
