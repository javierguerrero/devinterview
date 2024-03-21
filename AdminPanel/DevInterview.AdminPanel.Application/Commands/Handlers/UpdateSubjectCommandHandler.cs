using AutoMapper;
using DevInterview.AdminPanel.Domain.Entities;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, string>
    {
        private readonly ISubjectRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateSubjectCommandHandler(ISubjectRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {

            var role = new Subject
            {
                SubjectId = request.roleId,
                Name = request.name,
                Image = request.image
            };
            return await _roleRepository.UpdateSubject(role);
        }
    }
}
