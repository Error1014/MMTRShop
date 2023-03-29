namespace Orders.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }
        IOrderContentRepository OrderContents { get; }
        IStatusRepository Status { get; }
        int Complete();
    }
}
