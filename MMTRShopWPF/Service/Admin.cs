using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Admin
    {
        [Key()]
        public int Id { get; set; }
        [Required]
        public virtual User User { get; set; }
    }
}
