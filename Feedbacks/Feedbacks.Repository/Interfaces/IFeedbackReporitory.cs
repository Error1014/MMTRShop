using Shop.Infrastructure.Repository;

namespace Feedbacks.Repository.Interfaces
{
    public interface IFeedbackReporitory : IRepository<Feedback, Guid>
    {
    }
}
