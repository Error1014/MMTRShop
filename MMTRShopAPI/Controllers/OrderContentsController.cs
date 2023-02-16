using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.HelperModels;
using MMTRShop.Service.Interface;

namespace MMTRShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderContentsController : Controller
    {
        private readonly IOrderContentService _orderContentService;
        public OrderContentsController(IOrderContentService orderContentService)
        {
            _orderContentService = orderContentService;
        }

        [HttpGet("{id}")]
        public async Task<IEnumerable<OrderContentDTO>> GetOrderContentsByOrderId(Guid id)
        {
            var order = await _orderContentService.GetOrderContents(id);
            return order;
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.AddOrderContent(orderContentDTO);
            return Ok(orderContentDTO);
        }

        [HttpPut]
        public async Task<IActionResult> PutOrderContent(OrderContentDTO orderContentDTO)
        {
            await _orderContentService.Update(orderContentDTO);
            return Ok(orderContentDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderContent(Guid id)
        {
            await _orderContentService.Remove(id);
            return Ok($"Заказ с id={id} успешно удалён"); ;
        }
    }
}
