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

        public async Task<List<Status>> GetAll()
        {
            var list =await _unitOfWork.Status.GetAllAsync();
            return list.ToList();
        }
        public async Task<Status> GetStatus(Order order)
        {
            return await _unitOfWork.Status.FindAsync(s=>s.Id == order.StatusId);
        }
        public Status GetStatusWaitingPlaced()
        {
            return _unitOfWork.Status.SetStatusWaitingPlaced();
        }
    }
}
