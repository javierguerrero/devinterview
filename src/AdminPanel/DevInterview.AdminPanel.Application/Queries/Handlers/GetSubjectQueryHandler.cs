using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectResponse>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetSubjectQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<SubjectResponse> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            var response = await _webApiGatewayCommunication.GetSubject(request.subjectId);
            var subject = new SubjectResponse
            {
                Id = response.Id,
                Name = response.Name,
                Image = response.Image
            };
            return subject;
        }
    }
}