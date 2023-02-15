using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.MiddlewareException.Exceptions
{
    public class DublicateException:Exception
    {
        public DublicateException(string message) : base(message)
        {
        }
    }
}
