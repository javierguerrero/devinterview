using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, string>
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<string> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
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