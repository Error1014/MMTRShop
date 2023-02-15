﻿using AutoMapper;
using MMTRShop.DTO.DTO;
using MMTRShop.Model.Models;

namespace MMTRShop.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDTO>(); 
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Brand, BrandDTO>();
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<BankCard, BankCardDTO>();
            CreateMap<BankCard, BankCardDTO>().ReverseMap();
        }
    }
}
