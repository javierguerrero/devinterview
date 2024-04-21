using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record CreateQuestionCommand(string questionText, string answerText, int topicId) : IRequest<string>;
}
