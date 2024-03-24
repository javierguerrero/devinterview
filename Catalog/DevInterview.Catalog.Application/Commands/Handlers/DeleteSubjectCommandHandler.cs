using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand, bool>
    {
        private readonly ISubjectRepository _roleRepository;

        public DeleteSubjectCommandHandler(ISubjectRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            return await _roleRepository.DeleteSubject(request.id);
        }
    }
}