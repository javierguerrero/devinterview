using AutoMapper;
using DevInterview.Catalog.Application.Responses;
using DevInterview.Catalog.Domain.Interfaces;
using MediatR;

namespace DevInterview.Catalog.Application.Queries.Handlers
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
            var subject = await _roleRepository.GetAsync(request.subjectId);
            return _mapper.Map<SubjectResponse>(subject);
        }
    }
}