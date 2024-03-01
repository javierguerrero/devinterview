using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, string>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<string> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            var question = new Question()
            {
                Id = request.Id,
                QuestionText = request.questionText,
                AnswerText = request.answerText,
                TopicId = request.topicId
            };

            return await _questionRepository.UpdateQuestion(question);
        }
    }
}