using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Domain.Entities;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public UpdateQuestionCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(UpdateQuestionCommand request, CancellationToken cancellationToken)
        {
            //var question = new Question()
            //{
            //    Id = request.Id,
            //    QuestionText = request.questionText,
            //    AnswerText = request.answerText,
            //    TopicId = request.topicId
            //};

            //return await _questionRepository.UpdateQuestion(question);

            return null;
        }
    }
}