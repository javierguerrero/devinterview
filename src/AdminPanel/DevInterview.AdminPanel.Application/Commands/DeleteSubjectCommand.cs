using MediatR;
namespace DevInterview.AdminPanel.Application.Commands
{
    public record DeleteSubjectCommand(int id) : IRequest<bool>;
}