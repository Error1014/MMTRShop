using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetOrders();
        Task<IEnumerable<OrderDTO>> GetOrders(OrderFilter filter);
        Task<OrderDTO> GetOrder(Guid orderId);
        Task AddOrder(OrderDTO order);
        Task Save();
        Task Update(OrderDTO orderDTO);
        Task Remove(Guid orderId);


        //#region Проверки введёных полей

        //bool CheckWrittenRequisitesBankCard(BankCard bankCard);
        //bool CheckCorrectnessRequisitesBankCard(BankCard bankCard);
        
        //bool CheckAddress(string address);
        //#endregion

    }
}
