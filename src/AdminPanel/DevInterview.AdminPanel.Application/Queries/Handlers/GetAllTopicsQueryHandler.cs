using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicsQuery, IEnumerable<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public GetAllTopicQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopicResponse>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetAllTopics();
            return _mapper.Map<IEnumerable<TopicResponse>>(topics);
        }
    }
}
