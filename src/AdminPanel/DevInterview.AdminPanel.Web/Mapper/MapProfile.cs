using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Web.Models;

namespace DevInterview.AdminPanel.Web.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Subject, SubjectResponse>().ReverseMap();
            CreateMap<Topic, TopicResponse>().ReverseMap();
            CreateMap<Question, QuestionResponse>();

            CreateMap<SubjectResponse, SubjectViewModel>().ReverseMap();
            CreateMap<TopicResponse, TopicViewModel>().ReverseMap();
            CreateMap<QuestionResponse, QuestionViewModel>().ReverseMap();
        }
    }
}