using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Subject>
    {
        private readonly ISubjectRepository _roleRepository;

        public CreateSubjectCommandHandler(ISubjectRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<Subject> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Subject() { Name = request.name, Image = request.image };
            return await _roleRepository.CreateAsync(subject);
        }
    }
}