using AutoMapper;
using TutorBay.Basket.Api.Data;
using TutorBay.Basket.Api.Dto;

namespace TutorBay.Basket.Api
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<Data.Basket, BasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
        }
    }
}
