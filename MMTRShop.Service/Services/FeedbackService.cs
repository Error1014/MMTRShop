using AutoMapper;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using Shop.Infrastructure.DTO;
using Shop.Infrastructure.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShop.Service.Services
{
    public class FeedbackService: IFeedbackService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FeedbackService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddFeedback(FeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            _unitOfWork.Feedbacks.Add(feedback);
            await Save();
        }

        public async Task<FeedbackDTO> GetFeedback(Guid id)
        {
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(id);
            var result = _mapper.Map<FeedbackDTO>(feedback);
            return result;
        }

        public async Task<IEnumerable<FeedbackDTO>> GetFeedbacks(BaseFilter filter)
        {
            var feedback = await _unitOfWork.Feedbacks.GetPageElements(filter);
            var result = _mapper.Map<IEnumerable<FeedbackDTO>>(feedback);
            return result;
        }

        public async Task Remove(Guid Id)
        {
            var feedback = await _unitOfWork.Feedbacks.GetByIdAsync(Id);
            _unitOfWork.Feedbacks.Remove(feedback);
            await Save();
        }

        public async Task Save()
        {
           await _unitOfWork.Feedbacks.SaveAsync();
        }

        public async Task Update(FeedbackDTO feedbackDTO)
        {
            var feedback = _mapper.Map<Feedback>(feedbackDTO);
            _unitOfWork.Feedbacks.Update(feedback);
            await Save();
        }
    }
}
