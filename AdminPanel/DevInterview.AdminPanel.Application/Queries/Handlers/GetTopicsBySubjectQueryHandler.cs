using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetTopicsBySubjectQueryHandler : IRequestHandler<GetTopicsBySubjectQuery, IEnumerable<TopicResponse>>
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        public GetTopicsBySubjectQueryHandler(ITopicRepository topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TopicResponse>> Handle(GetTopicsBySubjectQuery request, CancellationToken cancellationToken)
        {
            var topics = await _topicRepository.GetTopicsBySubject(request.subjectId);
            return _mapper.Map<IEnumerable<TopicResponse>>(topics);
        }
    }
}