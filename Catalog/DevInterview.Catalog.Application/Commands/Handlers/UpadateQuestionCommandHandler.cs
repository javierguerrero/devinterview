using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, int>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<int> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
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