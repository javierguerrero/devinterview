using DevInterview.Students.Application.Responses;
using MediatR;

namespace DevInterview.Students.Application.Queries
{
    public record GetStudentQuery(int studentId) : IRequest<StudentResponse>;
}