using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record CreateTopicCommand(string name, string description, int subjectId) : IRequest<string>;
}
