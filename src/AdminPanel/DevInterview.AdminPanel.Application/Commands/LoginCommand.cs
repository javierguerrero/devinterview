using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record LoginCommand(string username, string password) : IRequest<LoginResponse>;
}
