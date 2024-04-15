using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateSubjectCommand(int subjectId, string name, string image) : IRequest<string>;
}
