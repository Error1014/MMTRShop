using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShop.Service.Services
{
    public class OrderService: IOrderService
    {
        private Message Message = new Message();
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ObservableCollection<Order>> GetOrders()
        {
            var orders =await _unitOfWork.Orders.GetAllAsync();
            return new ObservableCollection<Order>(orders.ToList());
        }
        public async Task<IEnumerable<Order>> GetOrderByClientId(Guid clientId)
        {
            return await _unitOfWork.Orders.GetOrdersByClientId(clientId);
        }
        public async Task<Order> GetOrderById(Guid orderId)
        {
            return await _unitOfWork.Orders.FindAsync(o=>o.Id==orderId);
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
