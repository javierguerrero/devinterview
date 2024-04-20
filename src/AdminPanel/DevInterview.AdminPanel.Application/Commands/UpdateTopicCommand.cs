using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateTopicCommand(int topicId, string name, string description, int subjectId) : IRequest<string>;
}
