using Feedbacks.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Infrastructure;
using Shop.Infrastructure.Attributes;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Feedbacks.Api.Controllers
{
    public class FeedbacksController : BaseApiController
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbacksController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [RoleAuthorize("Admin Client")]
        [HttpGet]
        public async Task<IEnumerable<FeedbackDTO>> GetFeedbacksPage([FromQuery] BaseFilter filter)
        {
            var feedback = await _feedbackService.GetFeedbacks(filter);
            return feedback;
        }
        [RoleAuthorize("Admin Client")]
        [HttpGet("{id}")]
        public async Task<FeedbackDTO> GetFeedback(Guid id)
        {
            var feedback = await _feedbackService.GetFeedback(id);
            return feedback;
        }
        [RoleAuthorize("Admin Client")]
        [HttpPost]
        public async Task<IActionResult> PostFeedback(FeedbackDTO feedbackDTO)
        {
            await _feedbackService.AddFeedback(feedbackDTO);
            return Ok(feedbackDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpPut]
        public async Task<IActionResult> PutFeedbackt(FeedbackDTO feedbackDTO)
        {
            await _feedbackService.Update(feedbackDTO);
            return Ok(feedbackDTO);
        }
        [RoleAuthorize("Admin Client")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeedback(Guid id)
        {
            await _feedbackService.Remove(id);
            return Ok($"Отзыв с id={id} успешно удалён");
        }
    }
}
