using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetAllRolesQuery : IRequest<IEnumerable<RoleResponse>>;
}
