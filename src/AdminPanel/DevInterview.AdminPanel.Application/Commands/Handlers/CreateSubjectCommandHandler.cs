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
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, string>
    {
        private readonly ISubjectRepository _roleRepository;

        public CreateSubjectCommandHandler(ISubjectRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<string> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var role = new Subject() { Name = request.name, Image = request.image };
            return await _roleRepository.CreateSubject(role);
        }
    }
}