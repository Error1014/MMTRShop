using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.Service.Interfaces;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Orders.Api.Controllers
{

    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [RoleAuthorize("Admin Client")]
        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> GetOrdersPage([FromQuery] OrderFilter filter)
        {
            var orders = await _orderService.GetOrders(filter);
            return orders;
        }
        [RoleAuthorize("Admin Client")]
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);
            return order;
        }
        [RoleAuthorize("Admin Client")]
        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderDTO orderDTO)
        {
            await _orderService.AddOrder(orderDTO);
            return Ok(orderDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpPut]
        public async Task<IActionResult> PutOrder(OrderDTO orderDTO)
        {
            await _orderService.Update(orderDTO);
            return Ok(orderDTO);
        }
        [RoleAuthorize("Admin Operator")]
        [HttpPut(nameof(PutOrderStatus))]
        public async Task<IActionResult> PutOrderStatus(Guid orderId, int statusId)
        {
            await _orderService.Update(orderId, statusId);
            return Ok(orderId);
        }
        [RoleAuthorize("Admin Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.Remove(id);
            return Ok($"Заказ с id={id} успешно удалён"); ;
        }
    }
}
