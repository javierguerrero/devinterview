using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateQuestionCommand(int Id, string questionText, string answerText, int topicId) : IRequest<string>;
}
