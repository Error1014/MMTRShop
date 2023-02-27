using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using System.Data;

namespace MMTRShopAPI.Controllers
{
    public class FeedbacksController : BaseApiController
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet]
        public async Task<IEnumerable<FeedbackDTO>> GetFeedbacksPage([FromQuery] BaseFilter filter)
        {
            var feedback = await _feedbackService.GetFeedbacks(filter);
            return feedback;
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpGet("{id}")]
        public async Task<FeedbackDTO> GetFeedback(Guid id)
        {
            var feedback = await _feedbackService.GetFeedback(id);
            return feedback;
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpPost]
        public async Task<IActionResult> PostFeedback(FeedbackDTO feedbackDTO)
        {
            await _feedbackService.AddFeedback(feedbackDTO);
            return Ok(feedbackDTO);
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpPut]
        public async Task<IActionResult> PutFeedbackt(FeedbackDTO feedbackDTO)
        {
            await _feedbackService.Update(feedbackDTO);
            return Ok(feedbackDTO);
        }
        [Authorize(Roles = "Admin, Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            await _feedbackService.Remove(id);
            return Ok($"Отзыв с id={id} успешно удалён");
        }
    }
}
