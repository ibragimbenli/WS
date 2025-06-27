using App_Service_Layer.DTOs;
using AutoMapper;
using Model_Layer.Entities;

namespace App_Service_Layer.Mapping
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            //CreateMap<Person, PersonDto>()
            //.ForMember(dest => dest.Age, opt => opt.MapFrom(src =>
            //                                        DateTime.Now.Year - src.BirthDate.Year));
            CreateMap<Person, PersonDto>()
                        .ForMember(dest => dest.FullName, opt =>
                                        opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                        .ForMember(dest => dest.Age, opt =>
                                        opt.MapFrom(src => DateTime.Now.Year - src.BirthDate.Year));

            CreateMap<CreatePersonDto, PersonDto>();

        }
    }
}
