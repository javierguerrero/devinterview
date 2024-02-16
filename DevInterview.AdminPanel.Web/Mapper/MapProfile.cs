using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using DevInterview.AdminPanel.Web.Models;

namespace DevInterview.AdminPanel.Web.Mapper
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<RoleFirebase, Role>().ReverseMap();
            CreateMap<TopicFirebase, Topic>().ReverseMap();
            CreateMap<QuestionFirebase, Question>().ReverseMap();
            CreateMap<AnswerFirebase, Answer>().ReverseMap();

            CreateMap<Role, RoleResponse>().ReverseMap();
            CreateMap<Topic, TopicResponse>().ReverseMap();

            CreateMap<RoleResponse, RoleViewModel>().ReverseMap();
            CreateMap<TopicResponse, TopicViewModel>().ReverseMap();
        }
    }
}
