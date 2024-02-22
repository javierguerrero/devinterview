using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
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
