using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public class BankCard:BaseEntity<Guid>
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Mont { get; set; }
        public int Year { get; set; }
        public string Code { get; set; }

        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }


    }
}
