using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Entities
{
    public class Client: BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual List<Cart>? Cart { get; set; }
        public virtual List<Feedback>? Feedback { get; set; }
        public virtual List<BankCard>? BankCards { get; set; }
        public virtual List<Order>? Order { get; set; }

        public Client()
        {

        }

        public Client(Guid userId,string email, string phone, string address)
        {
            UserId = userId;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
