using Shop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class UserSession : IUserSessionGetter, IUserSessionSetter
    {
        private Guid Id { get; set; }
        private string Role { get; set; }


        public Guid GetId()
        {
            return Id;
        }
        public string GetRole()
        {
            return Role;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void SetRole(string role)
        {
            Role = role;
        }
    }


}
