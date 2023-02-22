using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.HelperModels
{
    public class OrderFilter:FilterByClient
    {
        public int? StatusId { get; set; }
    }
}
