using AutoMapper;
using MMTRShop.DTO.DTO;
using MMTRShop.MiddlewareException.Exceptions;
using MMTRShop.Model.Models;
using MMTRShop.Repository.Interface;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MMTRShop.Service.Services
{
    public class BankCardService : IBankCardService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BankCardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BankCardDTO>> GetBankCards()
        {
            var bankCards = await _unitOfWork.BankCards.GetAllAsync();
            var result = _mapper.Map<IEnumerable<BankCardDTO>>(bankCards);
            return result;
        }
        public async Task<BankCardDTO> GetBankCard(Guid bankCardId)
        {
            var bancCard = await _unitOfWork.BankCards.GetByIdAsync(bankCardId);
            if (bancCard == null)
            {
                throw new NotFoundException("Банковская карта не найдена");
            }
            var result = _mapper.Map<BankCardDTO>(bancCard);
            return result;
        }
        public async Task AddBankCard(BankCardDTO bankCardDTO)
        {
            var bankCard = _mapper.Map<BankCard>(bankCardDTO);
            await _unitOfWork.BankCards.AddAsync(bankCard);
            await Save();
        }
        public async Task Update(BankCardDTO bankCardDTO)
        {
            var bankCard = _mapper.Map<BankCard>(bankCardDTO);
            _unitOfWork.BankCards.Update(bankCard);
            await Save();
        }
        public async Task Remove(Guid bankCardId)
        {
            var bancCard = await _unitOfWork.BankCards.GetByIdAsync(bankCardId);
            if (bancCard == null)
            {
                throw new NotFoundException("Банковская карта не найдена");
            }
            _unitOfWork.BankCards.Remove(bankCardId);
            await Save();
        }
        public async Task Save()
        {
           await _unitOfWork.BankCards.SaveAsync();
        }
        public ObservableCollection<int> GetAllMonth()
        {
            ObservableCollection<int> months = new ObservableCollection<int>();
            for (int i = 1; i <= 12; i++)
            {
                months.Add(i);
            }
            return months;
        }

        public ObservableCollection<int> GetYear(int quantityYear)
        {
            ObservableCollection<int> year = new ObservableCollection<int>();
            DateTime dateTime = DateTime.Now;
            for (int i = dateTime.Year - 2; i < dateTime.Year + quantityYear; i++)
            {
                year.Add(i);
            }
            return year;
        }
    }
}
