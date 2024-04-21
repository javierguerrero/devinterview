using AutoMapper;
using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetTopicsBySubjectQueryHandler : IRequestHandler<GetTopicsBySubjectQuery, IEnumerable<TopicResponse>>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetTopicsBySubjectQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<IEnumerable<TopicResponse>> Handle(GetTopicsBySubjectQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var topics = new List<TopicResponse>();
                var response = await _webApiGatewayCommunication.GetTopicsBySubject(request.subjectId);

                foreach (var topic in response)
                {
                    topics.Add(new TopicResponse
                    {
                        Id = topic.Id,
                        Name = topic.Name,
                        Description = topic.Description,
                        SubjectId = topic.SubjectId
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