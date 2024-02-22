using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetTopicsByRoleQueryHandler : IRequestHandler<GetTopicsByRoleQuery, IEnumerable<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public GetTopicsByRoleQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopicResponse>> Handle(GetTopicsByRoleQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetTopicsByRole(request.roleId);
            return _mapper.Map<IEnumerable<TopicResponse>>(topics);
        }
    }
}