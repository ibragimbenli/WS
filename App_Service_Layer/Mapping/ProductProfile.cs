using App_Service_Layer.DTOs;
using AutoMapper;
using Model_Layer.Entities;

namespace App_Service_Layer.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                        .ForMember(dest => dest.Name, opt =>
                                        opt.MapFrom(src => src.ProductName))
                        .ForMember(dest => dest.Category, opt =>
                                        opt.MapFrom(src => src.Category.CategoryName))
                        .ForMember(dest => dest.Price, opt =>
                                        opt.MapFrom(src => src.UnitPrice)); ;

            CreateMap<CreatePersonDto, ProductDto>();
        }
    }
}