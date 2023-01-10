using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Product
    {
        [Key()]
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public int? BrandId { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brand Brand { get; set; }
        public virtual List<Cart> Cart { get; set; }
    }
}
