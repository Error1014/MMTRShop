using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccountMicroservice.PersonalAccount.Repository.Entities
{
    public class Client: User
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public Client()
        {

        }

        public Client(Guid userId,string email, string phone, string address)
        {
            //UserId = userId;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
