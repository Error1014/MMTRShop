using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Exceptions
{
    public class RestrictionOfGoodsException : Exception
    {
        public RestrictionOfGoodsException(string message) : base(message)
        {
        }
    }
}
