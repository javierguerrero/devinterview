using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetTopicsBySubjectQuery(int subjectId) : IRequest<IEnumerable<TopicResponse>>;
}
