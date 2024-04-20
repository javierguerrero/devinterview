using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public CreateTopicCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _webApiGatewayCommunication.CreateTopic(new TopicWebApiGatewayCommunicationRequest
                {
                    Name = request.name,
                    Description = request.description,
                    SubjectId = request.subjectId
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