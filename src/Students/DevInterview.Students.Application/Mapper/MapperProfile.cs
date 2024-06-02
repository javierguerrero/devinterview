using AutoMapper;
using DevInterview.Students.Application.Responses;
using DevInterview.Students.Domain.Entities;

namespace DevInterview.Students.Application.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Student, StudentResponse>().ReverseMap();
        }
    }
}