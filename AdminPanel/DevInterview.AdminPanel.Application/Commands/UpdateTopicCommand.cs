using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateTopicCommand(string topicId, string name, string description, string roleId) : IRequest<string>;
}
