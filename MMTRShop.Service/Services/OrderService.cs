using MMTRShop.MiddlewareException.Exceptions;
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

        public bool CheckWrittenRequisitesBankCard(BankCard bankCard)
        {
            if (String.IsNullOrEmpty(bankCard.Number)
                || String.IsNullOrEmpty(bankCard.Name)
                || String.IsNullOrEmpty(bankCard.Code)
                || bankCard.Month == 0
                || bankCard.Year == 0
                ) throw new ValidationException("Вы ввели не все данные карты");
            else return true;
        }
        public bool CheckCorrectnessRequisitesBankCard(BankCard bankCard)
        {
            //В дальнейшем будет реализовано
            return false;
        }

        public bool CheckAddress(string address)
        {
            if (String.IsNullOrEmpty(address))
            {
                throw new ValidationException("Вы не указали адрес");
            }
            return true;
        }
        #endregion

        

    }
}
