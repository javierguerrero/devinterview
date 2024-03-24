using AutoMapper;
using DevInterview.Catalog.Application.Responses;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Queries.Handlers
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