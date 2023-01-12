using MMTRShopWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Service
{
    public class AccountManager
    {
        private static User user;
        private static Admin admin;
        private static Client client;
        private static Operator _operator;
        public static User User 
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public static Admin Admin
        {
            get { return admin; } 
            set 
            {
                admin = value;
                client = null;
                _operator = null;
            } 
        }
        public static Client Client
        {
            get { return client; }
            set
            {
                admin = null;
                client = value;
                _operator = null;
            }
        }

        public static Operator Operator
        {
            get { return _operator; }
            set
            {
                admin = null;
                client = null;
                _operator = value;
            }
        }
        public static void ResetAccount()
        {
            User = null;
            Admin = null;
            Client = null;
            Operator = null;
        }
    }
}
