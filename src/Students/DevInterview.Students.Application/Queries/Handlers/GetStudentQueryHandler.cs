using AutoMapper;
using DevInterview.Students.Application.Responses;
using DevInterview.Students.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Students.Application.Queries.Handlers
{
    public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentResponse>
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public GetStudentQueryHandler(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _repository.GetAsync(request.studentId);
            return _mapper.Map<StudentResponse>(student);
        }
    }
}
