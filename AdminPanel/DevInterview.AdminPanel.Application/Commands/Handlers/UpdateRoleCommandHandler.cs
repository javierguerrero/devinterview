using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommandHandler(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {

            var role = new Role
            {
                RoleId = request.roleId,
                Name = request.name,
                Image = request.image
            };
            return await _roleRepository.UpdateRole(role);
        }
    }
}
