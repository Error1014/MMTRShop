using MMTRShop.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Interface
{
    public interface IFeedbackService
    {
        void AddFeedback(Feedback feedback);
        void SaveFeedback();
    }
}
