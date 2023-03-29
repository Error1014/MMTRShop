namespace Feedbacks.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IFeedbackReporitory Feedbacks { get; }
        int Complete();
    }
}
