using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public CreateSubjectCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _webApiGatewayCommunication.CreateSubject(new SubjectWebApiGatewayCommunicationRequest
                {
                    Name = request.name,
                    Image = request.image
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