using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    public record CreateTopicCommand(string name, string description, int subjectId) : IRequest<int>;
}
