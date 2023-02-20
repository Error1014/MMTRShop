using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{

    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        [HttpPost(nameof(GetProductsPage))]
        public async Task<IEnumerable<OrderDTO>> GetProductsPage([FromBody]OrderFilter filter)
        {
            var orders = await _orderService.GetOrders(filter);
            return orders;
        }
        [HttpGet("{id}")]
        public async Task<OrderDTO> GetOrder(Guid id)
        {
            var order = await _orderService.GetOrder(id);
            return order;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderDTO orderDTO)
        {
            await _orderService.AddOrder(orderDTO);
            return Ok(orderDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutOrder(OrderDTO orderDTO)
        {
            await _orderService.Update(orderDTO);
            return Ok(orderDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            await _orderService.Remove(id);
            return Ok($"Заказ с id={id} успешно удалён"); ;
        }
    }
}
