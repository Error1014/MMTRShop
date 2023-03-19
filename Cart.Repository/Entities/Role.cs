using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Authorization.Repository.Entities
{
    public class Role:BaseEntity<int>
    {
        public string Name { get; set; }
        public virtual List<User>? Users { get; set; }
    }
}
