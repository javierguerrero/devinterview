using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetTopicsByRoleQuery(string roleId) : IRequest<IEnumerable<TopicResponse>>;
}
