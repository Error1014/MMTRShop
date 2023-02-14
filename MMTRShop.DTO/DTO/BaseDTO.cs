using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.DTO.DTO
{
    public class BaseDTO<TKey> where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
