using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IOrderContentService
    {
        Task AddOrderContent(OrderContentDTO orderContentDTO);
        Task Remove(Guid orderId);
        Task Update(OrderContentDTO order);
        Task Save();
        Task<IEnumerable<OrderContentDTO>> GetOrderContents(Guid orderId);
    }
}
