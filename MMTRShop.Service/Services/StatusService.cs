using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Service.Services
{
    public class StatusService: IStatusService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StatusService(IUnitOfWork unitOfWork)
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
            return await _unitOfWork.Status.FindAsync(s=>s.Id == 1);
        }
        public Status GetStatusWaitingPlaced()
        {
            return _unitOfWork.Status.SetStatusWaitingPlaced();
        }
    }
}
