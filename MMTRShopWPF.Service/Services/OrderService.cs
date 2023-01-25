using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
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
    public class OrderService
    {
        private Message Message = new Message();
        private readonly UnitOfWork _unitOfWork;
        public OrderService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ObservableCollection<Order> GetOrders()
        {
            var orders = _unitOfWork.Orders.GetAll();
            return new ObservableCollection<Order>(orders);
        }
        public List<Order> GetOrderClient(Client client)
        {
            return _unitOfWork.Orders.GetOrdersByClientId(client.Id).ToList();
        }
        public Order GetOrder(Order order)
        {
            return _unitOfWork.Orders.Find(o=>o.Id==order.Id);
        }
        public void CreateOrder(Order order)
        {
            _unitOfWork.Orders.Add(order);
            SaveOrder();
        }
        public void SaveOrder()
        {
            _unitOfWork.Orders.Save();
        }

        
        
        #region Проверки введёных полей

        public Message CheckWrittenRequisitesBankCard(BankCard bankCard)
        {
            if (String.IsNullOrEmpty(bankCard.Number)
                || String.IsNullOrEmpty(bankCard.Name)
                || String.IsNullOrEmpty(bankCard.Code)
                //|| bankCard.Month == 0
                //|| bankCard.Year == 0
                ) return Message.GetMessage(true, "Вы ввели не все данные карты");
            else return Message.GetMessage(false);
        }
        public Message CheckCorrectnessRequisitesBankCard(BankCard bankCard)
        {
            //В дальнейшем будет реализовано
            return Message.GetMessage(false);
        }

        public Message CheckAddress(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                return Message.GetMessage(true, "Вы не указали адрес");
            }
            return new Message(false);
        }
        #endregion

        

    }
}
