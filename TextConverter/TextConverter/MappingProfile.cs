using AutoMapper;
using TextConverter.Dtos;
using TextConverter.Models;

namespace TextConverter.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Text, TextDto>();
            CreateMap<TextDto, Text>();
        }
    }
}