using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IBankCardService
    {
       ObservableCollection<int> GetAllMonth();
       ObservableCollection<int> GetYear(int quantityYear);
    }
}
