using AutoMapper;
using DevInterview.Catalog.Domain.Entities;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Commands.Handlers
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand, int>
    {
        private readonly ISubjectRepository _roleRepository;
        private readonly IMapper _mapper;

        public UpdateSubjectCommandHandler(ISubjectRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {

            var role = new Subject
            {
                Id = request.subjectId,
                Name = request.name,
                Image = request.image
            };
            return await _roleRepository.UpdateAsync(role);
        }
    }
}
