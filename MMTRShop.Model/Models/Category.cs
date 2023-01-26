using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Model.Models
{
    public class Category : BaseEntity<Guid>
    {
        public string Title { get; set; }
        public virtual List<Product> Product { get; set; }


        public Category()
        {

        }
        public Category(string title)
        {
            Title = title;
        }
    }
}
