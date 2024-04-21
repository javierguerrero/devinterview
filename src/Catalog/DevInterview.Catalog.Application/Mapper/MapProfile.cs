using DevInterview.Catalog.Application.Responses;
using DevInterview.Catalog.Domain.Entities;

namespace DevInterview.Catalog.Application.Mapper
{
    public class MapProfile : AutoMapper.Profile
    {
        public MapProfile()
        {
            CreateMap<Subject, SubjectResponse>().ReverseMap();
            CreateMap<Topic, TopicResponse>().ReverseMap();
            //CreateMap<Question, QuestionResponse>().ReverseMap();
            CreateMap<Question, QuestionResponse>().ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.Topic.SubjectId));
        }
    }
}