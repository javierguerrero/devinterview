using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, Question>
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question() { 
                QuestionText = request.questionText, 
                AnswerText = request.answerText, 
                TopicId = request.topicId 
            };

            return await _questionRepository.CreateQuestion(question);
        }
    }
}