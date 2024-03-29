﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAccount.Repository.Entities
{
    public class Client : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }


        public Client()
        {

        }
        public Client(Guid userId)
        {
            UserId = userId;
        }
        public Client(Guid userId, string email, string phone, string address)
        {
            UserId = userId;
            Email = email;
            Phone = phone;
            Address = address;
        }
    }
}
