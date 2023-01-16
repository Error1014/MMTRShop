using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class OrderService:BaseService
    {
        
        public static ObservableCollection<Order> GetOrders()
        {
            var orders = UnitOfWork.Orders.GetAll();
            return new ObservableCollection<Order>(orders);
        }
        public static List<Order> GetOrderClient(Client client)
        {
            return UnitOfWork.Orders.GetOrdersByClientId(client.Id).ToList();
        }
        public static void CreateOrder(Order order)
        {
            UnitOfWork.Orders.Add(order);
            SaveOrder();
        }
        public static void SaveOrder()
        {
            UnitOfWork.Orders.Save();
        }
        public static Order SetOrder(string address, bool IsPayNow, Status status)
        {
            return new Order(AccountManager.Client,address, IsPayNow, status.Id);
        }
        
        
        #region Проверки введёных полей

        public static bool CheckWrittenRequisitesBankCard(BankCard bankCard)
        {
            if (String.IsNullOrEmpty(bankCard.Number)
                || String.IsNullOrEmpty(bankCard.Name)
                || String.IsNullOrEmpty(bankCard.Code)
                || bankCard.Month == 0
                || bankCard.Year == 0) return false;
            else return true;
        }
        public static bool CheckCorrectnessRequisitesBankCard(BankCard bankCard)
        {
            //В дальнейшем будет реализовано
            return true;
        }

        public static bool CheckAddress(string address)
        {
            return !String.IsNullOrEmpty(address);
        }
        #endregion

        

    }
}
