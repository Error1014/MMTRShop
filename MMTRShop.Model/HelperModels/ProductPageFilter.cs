using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.HelperModels
{
    public class ProductPageFilter:BaseFilter
    {
        
        public Guid? CategoryId;
        public Guid? BrandId;
        public ProductPageFilter(int numPage, int sizePage, Guid? categoryId, Guid? bandId):base(numPage,sizePage)
        {
            CategoryId = categoryId;
            BrandId = bandId;
        }
    }
}
