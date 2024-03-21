using AutoMapper;
using DevInterview.AdminPanel.Application.Responses;
using DevInterview.AdminPanel.Domain.Interfaces;
using DevInterview.AdminPanel.Infrastructure.DataAccess.Repositories;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllSubjectsQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<SubjectResponse>>
    {
        private readonly ISubjectRepository _roleRepository;
        private readonly IMapper _mapper;

        public GetAllSubjectsQueryHandler(ISubjectRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectResponse>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleRepository.GetAllSubjects();
            return _mapper.Map<IEnumerable<SubjectResponse>>(roles);
        }
    }
}
