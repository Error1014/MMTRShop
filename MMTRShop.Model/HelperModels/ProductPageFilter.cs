using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MMTRShop.Model.HelperModels
{
    public class ProductPageFilter:BaseFilter
    {
        public Guid? CategoryId { get; set; }
        public Guid? BrandId { get; set; }
       
    }
}
