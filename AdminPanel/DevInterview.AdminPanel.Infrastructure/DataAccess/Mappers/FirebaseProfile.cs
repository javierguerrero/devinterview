using AutoMapper;
using DevInterview.AdminPanel.Infrastructure.DataAccess.FirebaseEntities;
using DevInterview.AdminPanel.Domain.Entities;

namespace DevInterview.AdminPanel.Infrastructure.DataAccess.Mappers
{
    public class FirebaseProfile : Profile
    {
        public FirebaseProfile()
        {
            CreateMap<RoleFirebase, Role>().ReverseMap();
            CreateMap<TopicFirebase, Topic>().ReverseMap();
            CreateMap<QuestionFirebase, Question>().ReverseMap();
            CreateMap<AnswerFirebase, Answer>().ReverseMap();
        }
    }
}