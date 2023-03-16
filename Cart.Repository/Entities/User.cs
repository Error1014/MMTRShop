﻿using Shop.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Authorization.Repository.Entities
{
    public abstract class User : BaseEntity<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

        public User()
        {

        }
        public User(string login, string password,string lastName,string firstName,string patronymic)
        {
            Login = login;
            Password = password;
            LastName = lastName;
            FirstName = firstName;
            Patronymic = patronymic;
        }
    }
}