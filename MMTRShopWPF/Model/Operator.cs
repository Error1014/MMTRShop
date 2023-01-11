using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public class Operator: BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
