using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RoleResponse>>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllRoles();
            return _mapper.Map<IEnumerable<RoleResponse>>(roles);
        }
    }
}
