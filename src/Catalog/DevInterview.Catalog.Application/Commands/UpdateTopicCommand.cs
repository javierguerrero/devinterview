using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    public record UpdateTopicCommand(int topicId, string name, string description, int subjectId) : IRequest<int>;
}
