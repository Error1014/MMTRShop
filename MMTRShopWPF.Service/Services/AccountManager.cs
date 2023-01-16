using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repositories.Repository;
using System;
using System.Linq;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class AccountManager:BaseService
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
        public static User GetUserByIdClient()
        {
            return ShopContext.GetContext().User.Where(user => user.Id == Client.UserId).FirstOrDefault();
        }
        public static User GetUserByIdAdmin()
        {
            return ShopContext.GetContext().User.Where(user => user.Id == Admin.UserId).FirstOrDefault();
        }
        public static User GetUserByIdOperator()
        {
            return ShopContext.GetContext().User.Where(user => user.Id == Operator.UserId).FirstOrDefault();
        }
        public static void SetRoleById(Guid id)
        {
            var user = UnitOfWork.Users.GetById(id);
            User = user;
            var admins = UnitOfWork.Admins.GetAll();
            foreach (var item in admins)
            {
                if (user.Id==item.UserId)
                {
                    Admin = UnitOfWork.Admins.GetAdminByUser(user);
                    return;
                }
            }
            var operators = UnitOfWork.Operators.GetAll();
            foreach (var item in operators)
            {
                if (user.Id == item.UserId)
                {
                    Operator = UnitOfWork.Operators.GetOperatorByUser(user);
                    return;
                }
            }
            var clients = UnitOfWork.Clients.GetAll();
            foreach (var item in clients)
            {
                if (user.Id == item.UserId)
                {
                    Client = UnitOfWork.Clients.GetClientByUser(user);
                    return;
                }
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
