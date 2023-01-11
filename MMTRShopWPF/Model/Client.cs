using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Model
{
    public class Client: BaseEntity<Guid>
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Emain { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        
        public Client()
        {

        }

        public Client(string emain, string phone, string address)
        {
            Emain = emain;
            Phone = phone;
            Address = address;
        }
    }
}
