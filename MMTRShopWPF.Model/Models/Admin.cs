using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model.Models
{
    public class Admin:BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
