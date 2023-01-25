using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MMTRShopWPF.Service.Services
{
    public class FeedbackService
    {
        private readonly UnitOfWork _unitOfWork;
        public FeedbackService(UnitOfWork unitOfWork)
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
