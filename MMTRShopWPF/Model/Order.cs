using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public class Order : BaseEntity<Guid>
    {
        public string Address { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateDelivery { get; set; }
        public int StatusID { get; set; }
        public virtual Status Status { get; set; }
    }
}
