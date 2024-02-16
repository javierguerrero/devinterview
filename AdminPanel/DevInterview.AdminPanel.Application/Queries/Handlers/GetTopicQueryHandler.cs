using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, TopicResponse>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public GetTopicQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<TopicResponse> Handle(GetTopicQuery request, CancellationToken cancellationToken)
        {
            var topic = await _topicRepository.GetTopic(request.topicId);
            return _mapper.Map<TopicResponse>(topic);
        }
    }
}