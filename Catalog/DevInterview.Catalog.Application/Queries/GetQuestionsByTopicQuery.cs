
using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DevInterview.Catalog.Application.Queries
{
    public record GetQuestionsByTopicQuery(int topicId) : IRequest<IEnumerable<QuestionResponse>>;
}
