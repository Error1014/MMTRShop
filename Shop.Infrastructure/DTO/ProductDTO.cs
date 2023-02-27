using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class ProductDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public string Photo { get; set; }
        public int CountInStarage { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }

        public string Status 
        {
            get
            {
                if (CountInStarage==0) return "Закончился";
                else return "Доступен";
            }
        }
    }
}
