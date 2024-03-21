using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetSubjectQueryHandler : IRequestHandler<GetSubjectQuery, SubjectResponse>
    {
        private readonly ISubjectRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetSubjectQueryHandler(ISubjectRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<SubjectResponse> Handle(GetSubjectQuery request, CancellationToken cancellationToken)
        {
            var role = await _roleRepository.GetSubject(request.roleId);
            return _mapper.Map<SubjectResponse>(role);
        }
    }
}