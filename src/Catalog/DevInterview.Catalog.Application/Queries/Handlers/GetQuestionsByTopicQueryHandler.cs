using AutoMapper;
using DevInterview.Catalog.Application.Responses;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Queries.Handlers
{
    public class GetQuestionsByTopicQueryHandler : IRequestHandler<GetQuestionsByTopicQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionsByTopicQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetQuestionsByTopicQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsByTopic(request.topicId);
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }
    }
}
