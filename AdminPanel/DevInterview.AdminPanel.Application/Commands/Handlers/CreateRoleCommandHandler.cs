using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleCommandHandler(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role() { Name = request.name, Image = request.image };
            return await _roleRepository.CreateRole(role);
        }
    }
}