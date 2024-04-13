using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetQuestionsByTopicQuery(string topicId) : IRequest<IEnumerable<QuestionResponse>>;
}
