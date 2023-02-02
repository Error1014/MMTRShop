﻿using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using System;
using System.Collections.ObjectModel;

namespace MMTRShop.Service.Services
{
    public  class BankCardService
    {
        private readonly UnitOfWork _unitOfWork;
        public BankCardService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            for (int i = dateTime.Year-2; i < dateTime.Year + quantityYear; i++)
            {
                year.Add(i);
            }
            return year;
        }
    }
}