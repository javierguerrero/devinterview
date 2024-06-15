using AutoMapper;
using DevInterview.Students.Application.Responses;
using DevInterview.Students.Domain.Entities;
using DevInterview.Students.Domain.Interfaces;
using MediatR;

namespace DevInterview.Students.Application.Commands.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student()
            {
                UserName = request.userName,
                FirstName = request.firstName,
                LastName = request.lastName
            };
            await _repository.CreateAsync(student);

            //_producer.Produce(_mapper.Map<StudentCreatedEvent>(request));

            var response = _mapper.Map<StudentResponse>(student);
            return response;
        }
    }
}