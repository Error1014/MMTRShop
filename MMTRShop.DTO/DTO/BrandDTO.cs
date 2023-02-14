using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.DTO.DTO
{
    public class BrandDTO:BaseDTO<Guid>
    {
        public string Name { get; set; }
    }
}
