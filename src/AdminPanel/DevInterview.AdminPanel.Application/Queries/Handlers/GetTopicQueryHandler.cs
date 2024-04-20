using AutoMapper;
using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetTopicQueryHandler : IRequestHandler<GetTopicQuery, TopicResponse>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetTopicQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<TopicResponse> Handle(GetTopicQuery request, CancellationToken cancellationToken)
        {
            var response = await _webApiGatewayCommunication.GetTopic(request.id);
            var topic = new TopicResponse
            {
                Id = response.Id,
                Name = response.Name,
                Description = response.Description
            };
            return topic;
        }
    }
}