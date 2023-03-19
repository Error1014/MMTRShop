using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Shop.Infrastructure;

namespace MMTRShopAPI.Controllers
{

    public class OrderContentsController : BaseApiController
    {
        private readonly IOrderContentService _orderContentService;
        public OrderContentsController(IOrderContentService orderContentService)
        {
            _orderContentService = orderContentService;
        }
        [Authorize(Roles = "Admin,Client")]
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderContentDTO>> GetOrderContentsByOrderId(Guid id)
        {
            var order = await _orderContentService.GetOrderContents(id);
            return order;
        }

        [Authorize(Roles = "Admin,Client")]
        [HttpPost]
        public async Task<IActionResult> PostOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.AddOrderContent(orderContentDTO);
            return Ok(orderContentDTO);
        }
        [Authorize(Roles = "Admin,Client")]
        [HttpPut]
        public async Task<IActionResult> PutOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.Update(orderContentDTO);
            return Ok(orderContentDTO);
        }
        [Authorize(Roles = "Admin,Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderContent(Guid id)
        {
            await _orderContentService.Remove(id);
            return Ok($"Заказ с id={id} успешно удалён"); ;
        }
    }
}
