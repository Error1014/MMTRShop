using MMTRShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.HelperModels
{
    public class BaseFilter
    {
        public int NumPage;
        public int SizePage;

        public BaseFilter(int numPage, int sizePage)
{
            NumPage = numPage;
            SizePage = sizePage;
        }
    }
}
