using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record DeleteQuestionCommand(int id) : IRequest<bool>;
}