using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class Feedback: BaseEntity<Guid>
    {
        public Guid ProductID { get; set; }
        public string Comment { get; set; }
        public byte Rating { get; set; }
        
        public int ClientID { get; set; }
        public virtual Product Product { get; set; }

        public virtual Client Client { get; set; }
    }
}
