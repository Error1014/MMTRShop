using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class OrderService:BaseService
    {
        public static void CreateOrder(Order order)
        {
            UnitOfWork.Orders.Add(order);
            UnitOfWork.Orders.Save();
        }
        public static Order GetOrder(string address, bool IsPayNow, Status status)
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
    }
}
