﻿using Shop.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Feedbacks.Repository
{
    public class Feedback : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public string Comment { get; set; }
        public byte Rating { get; set; }

        public Guid ClientId { get; set; }


        public Feedback()
        {

        }
        public Feedback(Guid clientId, Guid productId, byte rating, string comment)
        {
            ClientId = clientId;
            ProductId = productId;
            Rating = rating;
            Comment = comment;
        }
    }
}
