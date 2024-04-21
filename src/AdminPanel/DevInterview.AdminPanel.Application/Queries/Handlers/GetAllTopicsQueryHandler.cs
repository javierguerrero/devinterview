using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllTopicQueryHandler : IRequestHandler<GetAllTopicsQuery, IEnumerable<TopicResponse>>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetAllTopicQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<IEnumerable<TopicResponse>> Handle(GetAllTopicsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var topics = new List<TopicResponse>();
                var response = await _webApiGatewayCommunication.GetAllTopics();

                foreach (var topic in response)
                {
                    topics.Add(new TopicResponse
                    {
                        Id = topic.Id,
                        Name = topic.Name,
                        Description = topic.Description,
                        SubjectId = topic.SubjectId,
                        SubjectName = topic.SubjectName
                    });
                }
                return topics;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}