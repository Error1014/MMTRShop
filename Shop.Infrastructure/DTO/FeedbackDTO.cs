using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.DTO
{
    public class FeedbackDTO
    {
        public Guid ClientId { get; set; }
        public Guid ProductId { get; set; }
        public string Comment { get; set; }
        public byte Rating { get; set; }
        
    }
}
