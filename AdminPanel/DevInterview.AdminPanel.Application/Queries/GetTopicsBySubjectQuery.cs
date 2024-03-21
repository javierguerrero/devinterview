using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetTopicsBySubjectQuery(string subjectId) : IRequest<IEnumerable<TopicResponse>>;
}
