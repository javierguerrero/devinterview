using DevInterview.Students.Application.Responses;
using MediatR;

namespace DevInterview.Students.Application.Commands
{
    public record CreateStudentCommand(string userName, string firstName, string lastName, string password, string role) : IRequest<StudentResponse>;
}