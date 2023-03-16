using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartMicroservice.Carts.Repository.Entities
{
    public abstract class BaseEntity<TKey> where TKey : struct
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
    }
}
