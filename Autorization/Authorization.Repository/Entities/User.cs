using Shop.Infrastructure;
using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.Repository.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }
        public int? RoleId { get; set; }
        public virtual Role? Role { get; set; }

        public User()
        {

        }
        public User(string login, string password, string lastName, string firstName, string patronymic, int Role)
        {
            Login = login;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
        }
    }
}
