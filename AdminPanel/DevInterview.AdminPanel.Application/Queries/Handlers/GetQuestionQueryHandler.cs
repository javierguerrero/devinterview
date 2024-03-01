using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionResponse>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<QuestionResponse> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var question = await _questionRepository.GetQuestion(request.questionId);
            return _mapper.Map<QuestionResponse>(question);
        }
    }
}