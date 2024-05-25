using AutoMapper;
using DevInterview.Students.Application.Responses;
using DevInterview.Students.Domain.Entities;

namespace DevInterview.Students.Application.Mapper
{
    public class StudentsMapperProfile : Profile
    {
        public StudentsMapperProfile()
        {
            CreateMap<Student, StudentResponse>().ReverseMap();
        }
    }
}