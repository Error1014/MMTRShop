﻿using AutoMapper;
using Shop.Infrastructure.DTO;
using MMTRShop.Repository.Entities;

namespace MMTRShop.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BankCard, BankCardDTO>();
            CreateMap<BankCard, BankCardDTO>().ReverseMap();
            CreateMap<Favourite, FavouriteDTO>();
            CreateMap<Favourite, FavouriteDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderContent, OrderContentDTO>();
            CreateMap<OrderContent, OrderContentDTO>().ReverseMap();
            CreateMap<Feedback, FeedbackDTO>();
            CreateMap<Feedback, FeedbackDTO>().ReverseMap();
        }
    }
}
