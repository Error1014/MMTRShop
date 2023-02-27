using MMTRShop.Repository.Entities;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
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
