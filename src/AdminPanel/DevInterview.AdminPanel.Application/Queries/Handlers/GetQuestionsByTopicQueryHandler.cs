using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetQuestionsByTopicQueryHandler : IRequestHandler<GetQuestionsByTopicQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetQuestionsByTopicQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetQuestionsByTopicQuery request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}