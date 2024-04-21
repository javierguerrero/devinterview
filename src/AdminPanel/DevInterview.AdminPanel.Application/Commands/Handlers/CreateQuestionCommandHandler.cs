using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public CreateQuestionCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(CreateQuestionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _webApiGatewayCommunication.CreateQuestion(new QuestionWebApiGatewayCommunicationRequest
                {
                    QuestionText = request.questionText,
                    AnswerText = request.answerText,
                    TopicId = request.topicId
                });

                return response.Id.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}