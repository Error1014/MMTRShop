using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.HelperModels
{
    public class ProductPageFilter
    {
        public int NumPage;
        public int SizePage;
        public Guid? CategoryId;
        public Guid? BrandId;
        public ProductPageFilter(int numPage, int sizePage, Guid? categoryId, Guid? bandId)
        {
            NumPage = numPage;
            SizePage = sizePage;
            CategoryId = categoryId;
            BrandId = bandId;
        }
    }
}
