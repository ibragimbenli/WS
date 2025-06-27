using App_Service_Layer.DTOs;
using AutoMapper;
using Model_Layer.Entities;

namespace App_Service_Layer.Mapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryID))
                                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName))
                                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<CreateCategoryDto, CategoryDto>();
        }
    }
}