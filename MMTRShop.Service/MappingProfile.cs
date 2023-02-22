﻿using AutoMapper;
using Shop.Infrastructure.DTO;
using MMTRShop.Repository.Entities;

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
            CreateMap<User, UserDTO>();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Cart, CartDTO>();
            CreateMap<Cart, CartDTO>().ReverseMap();
            CreateMap<Favourite, FavouriteDTO>();
            CreateMap<Favourite, FavouriteDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderContent, OrderContentDTO>();
            CreateMap<OrderContent, OrderContentDTO>().ReverseMap();
        }
    }
}
