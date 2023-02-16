using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.DTO.DTO
{
    public class OrderContentDTO:BaseDTO<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int CountProduct { get; set; }
    }
}
