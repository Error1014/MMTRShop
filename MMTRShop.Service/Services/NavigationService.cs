using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class NavigationService
    {
        private Message Message = new Message();
        public Message CheckAutorisation()
        {
            if (AccountManager.User == null) return Message.GetMessage(true, "Для этого вам сперва необходимо войти в аккаутн") ;
            return new Message(false);
        }
    }
}
