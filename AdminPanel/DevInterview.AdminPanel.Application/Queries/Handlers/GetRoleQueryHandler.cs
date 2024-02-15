using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleResponse>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetRoleQueryHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<RoleResponse> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetRole(request.roleId);
            return _mapper.Map<RoleResponse>(role);
        }
    }
}