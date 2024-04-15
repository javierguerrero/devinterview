using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, string>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public UpdateSubjectCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<string> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            try
            {
                await _webApiGatewayCommunication.UpdateSubject(request.subjectId, new SubjectWebApiGatewayCommunicationRequest
                {
                    Id = request.subjectId,
                    Name = request.name,
                    Image = request.image
                });

                return request.subjectId.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}