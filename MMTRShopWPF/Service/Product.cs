using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Product
    {
        [Key()]
        public int ID { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public string Photo { get; set; }
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        public virtual List<Korzine> Korzine { get; set; }
    }
}
