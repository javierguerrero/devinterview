using AutoMapper;
using DevInterview.Catalog.Application.Responses;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Queries.Handlers
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
            var subjects = await _roleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubjectResponse>>(subjects);
        }
    }
}
