using DevInterview.Catalog.Domain.Entities;
using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    //TODO: Return "TopicResponse" instead of "Topic"
    public record CreateTopicCommand(string name, string description, int subjectId) : IRequest<Topic>;
}
