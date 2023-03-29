using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Repository.Entities
{
    public class Product : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        public int CountInStarage { get; set; }
        public Guid CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public Guid BrandId { get; set; }
        public virtual Brand? Brand { get; set; }

    }
}
