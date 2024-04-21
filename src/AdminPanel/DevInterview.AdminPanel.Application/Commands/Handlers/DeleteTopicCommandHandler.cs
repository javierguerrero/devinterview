using DevInterview.AdminPanel.Application.HttpCommunications;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class DeleteTopicCommandHandler : IRequestHandler<DeleteTopicCommand, bool>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public DeleteTopicCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<bool> Handle(DeleteTopicCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _webApiGatewayCommunication.DeleteTopic(request.id);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}