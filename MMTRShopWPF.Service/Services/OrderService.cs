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
        public static List<Cart> GetCart()
        {
            return UnitOfWork.Carts.GetAll().ToList();
        }
        public static ObservableCollection<Order> GetOrders()
        {
            var orders = UnitOfWork.Orders.GetAll();
            return new ObservableCollection<Order>(orders);
        }
        public static void CreateOrder(Order order)
        {
            UnitOfWork.Orders.Add(order);
            UnitOfWork.Orders.Save();
        }
        public static Order SetOrder(string address, bool IsPayNow, Status status)
        {
            return new Order(AccountManager.Client,address, IsPayNow, status.Id);
        }
        public static void CreateOrderContent(Order order)
        {
            var carts = UnitOfWork.Carts.GetCartByIdClient(AccountManager.Client.Id);
            List<OrderContent> cartOrders = new List<OrderContent>();
            foreach (var cartItem in carts)
            {
               cartOrders.Add(new OrderContent(order, cartItem));
            }
            UnitOfWork.OrderContents.AddRange(cartOrders);
            UnitOfWork.OrderContents.Save();
        }
        public static void ClearCart(List<Cart> carts)
        {
            UnitOfWork.Carts.RemoveRange(carts);
            UnitOfWork.Carts.Save();
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

        public static List<Status> GetAllStatus()
        {
            return UnitOfWork.Status.GetAll().ToList();
        }

        public static Status GetStatusByOrder(Order order)
        {
            return UnitOfWork.Status.GetStatusByOdrer(order);
        }
        public static Client GetClient(Order order)
        {
            return UnitOfWork.Clients.GetById(order.ClientId);
        }
    }
}
