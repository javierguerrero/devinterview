using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    public record UpdateSubjectCommand(int subjectId, string name, string image) : IRequest<int>;
}
