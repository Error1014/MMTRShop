﻿using AutoMapper;
using Shop.Infrastructure.DTO;
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
    public class OrderContentService: IOrderContentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OrderContentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task AddOrderContent(OrderContentDTO orderContentDTO)
        {
            var orderContent = _mapper.Map<OrderContent>(orderContentDTO);
            _unitOfWork.OrderContents.Add(orderContent);
            await Save();
        }
        
        public async Task<IEnumerable<OrderContentDTO>> GetOrderContents(Guid orderId)
        {
            var orderContents = await _unitOfWork.OrderContents.GetOrderContentsByOrderId(orderId);
            var result = _mapper.Map<IEnumerable<OrderContentDTO>>(orderContents);
            return result;
        }

        public async Task Remove(Guid orderId)
        {
            _unitOfWork.OrderContents.Remove(orderId);
            await Save();
        }
        public async Task Update(OrderContentDTO orderDTO)
        {
            var orderContent = _mapper.Map<OrderContent>(orderDTO);
            _unitOfWork.OrderContents.Update(orderContent);
            await Save();
        }
        public async Task Save()
        {
            await _unitOfWork.OrderContents.SaveAsync();
        }
    }
}
