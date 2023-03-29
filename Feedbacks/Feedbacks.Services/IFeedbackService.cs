using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;

namespace Feedbacks.Services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<FeedbackDTO>> GetFeedbacks(BaseFilter filter);
        Task<FeedbackDTO> GetFeedback(Guid id);
        Task AddFeedback(FeedbackDTO feedback);
        Task Save();
        Task Update(FeedbackDTO feedbackDTO);
        Task Remove(Guid Id);
    }
}
