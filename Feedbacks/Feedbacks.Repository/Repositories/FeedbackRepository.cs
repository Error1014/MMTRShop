using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Infrastructure.Repository;
using Feedbacks.Repository.Interfaces;
using Feedbacks.Repository.Context;

namespace Feedbacks.Repository.Repositories
{
    public class FeedbackRepository : Repository<Feedback, Guid>, IFeedbackReporitory
    {
        public FeedbackRepository(FeedbacksContext context) : base(context)
        {

        }
    }
}
