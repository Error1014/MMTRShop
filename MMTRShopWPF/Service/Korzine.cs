using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class Korzine
    {
        [Key()]
        public int ID { get; set; }
        
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
        public int ValueProduct { get; set; }

        public virtual User User { get; set; }

        public Korzine()
        {

        }
        public Korzine(int userID, int productID, int value)
        {
            UserID = userID;
            ProductID = productID;
            ValueProduct = value;
        }
    }
}
