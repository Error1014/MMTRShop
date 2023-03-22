using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccount.Repository.Entities
{
    public abstract class BaseEntity<TKey> where TKey : struct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public TKey UserId { get; set; }
    }
}
