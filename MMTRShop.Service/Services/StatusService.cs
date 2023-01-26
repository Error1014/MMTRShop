using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class StatusService
    {
        private readonly UnitOfWork _unitOfWork;
        public StatusService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Status> GetAll()
        {
            return _unitOfWork.Status.GetAll().ToList();
        }
        public Status GetStatus(Order order)
        {
            return _unitOfWork.Status.Find(s=>s.Id == order.StatusId);
        }
        public Status GetStatusWaitingPlaced()
        {
            return _unitOfWork.Status.SetStatusWaitingPlaced();
        }
    }
}
