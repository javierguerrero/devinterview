using DevInterview.AdminPanel.Application.HttpCommunications;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand, bool>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public DeleteQuestionCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<bool> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
        {
            return true;
        }
    }
}