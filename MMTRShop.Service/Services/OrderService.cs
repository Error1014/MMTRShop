using AutoMapper;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.Exceptions;
using MMTRShop.Repository;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
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
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDTO>> GetOrders()
        {
            var orders = await _unitOfWork.Orders.GetAllAsync();
            var result = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return result;
        }
        public async Task<IEnumerable<OrderDTO>> GetOrders(OrderFilter filter)
        {
            var orders = await _unitOfWork.Orders.GetOrders(filter);
            var result = _mapper.Map<IEnumerable<OrderDTO>>(orders);
            return result;
        }
        public async Task<OrderDTO> GetOrder(Guid orderId)
        {
            var order = await _unitOfWork.Orders.FindAsync(o => o.Id == orderId);
            var result = _mapper.Map<OrderDTO>(order);
            return result;
        }
        public async Task AddOrder(OrderDTO orderDTO)
        {

            var order = _mapper.Map<Order>(orderDTO);
            _unitOfWork.Orders.Add(order);
            await Save();
        }
        public async Task Update(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _unitOfWork.Orders.Update(order);
            await Save();
        }
        public async Task Remove(Guid orderId)
        {
            var user = await GetOrder(orderId);
            _unitOfWork.Users.Remove(orderId);
            await Save();
        }
        public async Task Save()
        {
            _unitOfWork.Orders.Save();
        }

        //#region Проверки введёных полей
        //public bool CheckWrittenRequisitesBankCard(BankCard bankCard)
        //{
        //    if (String.IsNullOrEmpty(bankCard.Number)
        //        || String.IsNullOrEmpty(bankCard.Name)
        //        || String.IsNullOrEmpty(bankCard.Code)
        //        || bankCard.Month == 0
        //        || bankCard.Year == 0
        //        ) throw new ValidationException("Вы ввели не все данные карты");
        //    else return true;
        //}
        //public bool CheckCorrectnessRequisitesBankCard(BankCard bankCard)
        //{
        //    //В дальнейшем будет реализовано
        //    return false;
        //}

        //public bool CheckAddress(string address)
        //{
        //    if (String.IsNullOrEmpty(address))
        //    {
        //        throw new ValidationException("Вы не указали адрес");
        //    }
        //    return true;
        //}
        //#endregion



    }
}
