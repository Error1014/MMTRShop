using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.HelperModels
{
    public class FilterByClient:BaseFilter
    {
        public Guid? ClientId { get; set; }
    }
}
