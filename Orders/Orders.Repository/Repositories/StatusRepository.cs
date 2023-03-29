using Orders.Repository.Context;
using Orders.Repository.Entities;
using Orders.Repository.Interfaces;
using Shop.Infrastructure.Repository;

namespace Orders.Repository.Repositories
{
    public class StatusRepository : Repository<Status, int>, IStatusRepository
    {
        private readonly OrderContext _orderContext;
        public StatusRepository(OrderContext orderContext) : base(orderContext)
        {
            _orderContext = orderContext;
        }

        //Продумать как это реализовать через enum
        public Status SetStatusWaitingPlaced()
        {
            return _orderContext.Status.Where(s => s.Title == "Ждёт подтверждения").First();
        }
        public Status SetStatusPlaced()
        {
            return _orderContext.Status.Where(s => s.Title == "Оформлен").First();
        }
        public Status Delivered()
        {
            return _orderContext.Status.Where(s => s.Title == "Доставлен").First();
        }

        public Status SetStatusCancelled()
        {
            return _orderContext.Status.Where(s => s.Title == "Отменён").First();
        }

        public Status SetStatusOnWay()
        {
            return _orderContext.Status.Where(s => s.Title == "В пути").First();
        }

        public Status SetStatusReceived()
        {
            return _orderContext.Status.Where(s => s.Title == "Получен").First();
        }


    }
}
