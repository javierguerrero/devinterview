using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public UpdateTopicCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _webApiGatewayCommunication.UpdateTopic(request.topicId, new TopicWebApiGatewayCommunicationRequest
                {
                    Id = request.topicId,
                    Name = request.name,
                    Description = request.description,
                    SubjectId = request.subjectId
                });

                return request.topicId.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}