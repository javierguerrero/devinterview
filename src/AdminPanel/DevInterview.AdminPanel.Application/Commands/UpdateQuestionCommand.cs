using MediatR;

namespace DevInterview.AdminPanel.Application.Commands
{
    public record UpdateQuestionCommand(string Id, string questionText, string answerText, string topicId) : IRequest<string>;
}
