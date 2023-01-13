using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class Status:BaseEntity<Guid>
    {
        public string Title { get; set; }
    }
}
