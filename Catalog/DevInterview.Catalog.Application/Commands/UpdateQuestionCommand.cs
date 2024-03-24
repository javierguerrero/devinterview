using MediatR;

namespace DevInterview.Catalog.Application.Commands
{
    public record UpdateQuestionCommand(int Id, string questionText, string answerText, int topicId) : IRequest<int>;
}
