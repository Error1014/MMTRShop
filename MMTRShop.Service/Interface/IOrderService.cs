using MMTRShop.Model.Models;
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
        Task<ObservableCollection<Order>> GetOrders();
        Task<IEnumerable<Order>> GetOrderClient(Client client);
        Task<Order> GetOrder(Order order);
        void CreateOrder(Order order);
        void SaveOrder();



        #region Проверки введёных полей

        Message CheckWrittenRequisitesBankCard(BankCard bankCard);
        Message CheckCorrectnessRequisitesBankCard(BankCard bankCard);
        
        Message CheckAddress(string address);
        #endregion

    }
}
