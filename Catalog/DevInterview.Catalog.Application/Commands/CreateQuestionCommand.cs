using DevInterview.Catalog.Domain.Entities;
using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    public record CreateQuestionCommand(string questionText, string answerText, int topicId) : IRequest<Question>;
}
