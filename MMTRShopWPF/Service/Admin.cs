using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Admin
    {
        [Key(), DatabaseGenerated(DatabaseGeneratedOption.Identity), ForeignKey("User")]
        public Guid Id { get; set; }
        public virtual User User { get; set; }
    }
}
