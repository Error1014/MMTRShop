﻿using Shop.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class UserSession : IUserSessionGetter, IUserSessionSetter
    {
        public Guid UserId { get; set; }
        public string Role { get; set; }

    }


}
