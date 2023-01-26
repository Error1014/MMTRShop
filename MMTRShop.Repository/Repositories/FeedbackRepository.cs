using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Repositories
{
    public class FeedbackRepository:Repository<Feedback,Guid>, IFeedbackReporitory
    {
        public FeedbackRepository(ShopContext context) : base(context)
        {

        }
    }
}
