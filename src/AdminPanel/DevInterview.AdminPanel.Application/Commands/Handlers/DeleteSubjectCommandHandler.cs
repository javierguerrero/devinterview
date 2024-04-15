using DevInterview.AdminPanel.Application.HttpCommunications;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public DeleteSubjectCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _webApiGatewayCommunication.DeleteSubject(request.id);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}