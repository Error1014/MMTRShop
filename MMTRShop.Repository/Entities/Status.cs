using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
{
    public class Status:BaseEntity<int>
    {
        public string Title { get; set; }
    }
}
