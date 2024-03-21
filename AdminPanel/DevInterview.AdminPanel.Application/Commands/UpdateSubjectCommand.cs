using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateSubjectCommand(string roleId, string name, string image) : IRequest<string>;
}
