using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Orders.Service.Interfaces;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;

namespace Orders.Api.Controllers
{

    public class OrderContentsController : BaseApiController
    {
        private readonly IOrderContentService _orderContentService;
        public OrderContentsController(IOrderContentService orderContentService)
        {
            _orderContentService = orderContentService;
        }
        [RoleAuthorize("Admin Client")]
        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderContentDTO>> GetOrderContentsByOrderId(Guid id)
        {
            var order = await _orderContentService.GetOrderContents(id);
            return order;
        }

        [RoleAuthorize("Admin Client")]
        [HttpPost]
        public async Task<IActionResult> PostOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.AddOrderContent(orderContentDTO);
            return Ok(orderContentDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpPut]
        public async Task<IActionResult> PutOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.Update(orderContentDTO);
            return Ok(orderContentDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderContent(Guid id)
        {
            await _orderContentService.Remove(id);
            return Ok($"Заказ с id={id} успешно удалён"); ;
        }
    }
}
