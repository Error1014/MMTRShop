using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Category
    {
        [Key()]
        public int ID { get; set; }
        public string Title { get; set; }
        public virtual List<Product> Product { get; set; }
    }
}
