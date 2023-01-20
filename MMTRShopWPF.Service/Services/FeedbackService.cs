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
        UnitOfWork UnitOfWork { get; set; }
        public FeedbackService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }

        public void AddFeedback(Feedback feedback)
        {
            UnitOfWork.Feedbacks.Add(feedback);
        }
        public void SaveFeedback()
        {
            UnitOfWork.Feedbacks.Save();
        }

    }
}
