using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetAllQuestionsQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetAllQuestions();
            return _mapper.Map<IEnumerable<QuestionResponse>>(questions);
        }
    }
}
