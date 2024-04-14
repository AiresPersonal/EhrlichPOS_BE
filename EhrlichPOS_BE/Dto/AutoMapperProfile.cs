using AutoMapper;
using EhrlichPOS_BE.Models;
using System.Data;

namespace EhrlichPOS_BE.Dto
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() 
        {

            CreateMap<PizzaTypeDto, PizzaType>();
            CreateMap<PizzaType, PizzaTypeDto>()
            .ForMember(e => e.PizzaTypeId, s => s.MapFrom(r => r.PizzaTypeId))
            .ForMember(e => e.Name, s => s.MapFrom(r => r.Name))
            .ForMember(e => e.Category, s => s.MapFrom(r => r.Category))
            .ForMember(e => e.Ingredients, s => s.MapFrom(r => r.Ingredients));

            CreateMap<Pizza, PostPizza>();
            CreateMap<PostPizza, Pizza>();
            CreateMap<Pizza, PizzaDto>()
            .ForMember(e => e.PizzaId, s => s.MapFrom(r => r.PizzaId))
            .ForMember(e => e.PizzaTypeId, s => s.MapFrom(r => r.PizzaTypeId))
            .ForMember(e => e.PizzaType, s => s.MapFrom(r => r.PizzaType.Name))
            .ForMember(e => e.Size, s => s.MapFrom(r => r.Size))
            .ForMember(e => e.Price, s => s.MapFrom(r => r.Price));

            CreateMap<OrderDto, Order>();
            CreateMap<Order, OrderDto>()
            .ForMember(e => e.OrderId, s => s.MapFrom(r => r.OrderId))
            .ForMember(e => e.Date, s => s.MapFrom(r => r.Date));

            CreateMap<OrderDetail, PostOrderDetailsDto>()
            .ForMember(e => e.OrderDetailsId, s => s.MapFrom(r => r.OrderDetailsId))
            .ForMember(e => e.OrderId, s => s.MapFrom(r => r.OrderId))
            .ForMember(e => e.PizzaId, s => s.MapFrom(r => r.PizzaId))
            .ForMember(e => e.Quantity, s => s.MapFrom(r => r.Quantity));
        }
    }
}
