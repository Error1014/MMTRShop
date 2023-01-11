using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public abstract class BaseEntity<Guid>
    {
        public Guid Id { get; set; }
    }
}
