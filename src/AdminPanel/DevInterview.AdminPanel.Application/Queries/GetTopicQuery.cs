using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetTopicQuery(int id) : IRequest<TopicResponse>;
}
