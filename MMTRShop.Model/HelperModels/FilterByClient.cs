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

        public FilterByClient(int numPage, int sizePage, Guid? clietId):base(numPage, sizePage)
        {
            ClientId = clietId;
        }
    }
}
