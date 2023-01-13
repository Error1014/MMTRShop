using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class BankCard:BaseEntity<Guid>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string Code { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }


    }
}
