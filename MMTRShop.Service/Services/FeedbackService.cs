using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
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
        public FeedbackService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddFeedback(Feedback feedback)
        {
            _unitOfWork.Feedbacks.Add(feedback);
        }
        public void SaveFeedback()
        {
            _unitOfWork.Feedbacks.Save();
        }

    }
}
