using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DevInterview.Catalog.Application.Queries
{
    public record GetTopicsBySubjectQuery(int subjectId) : IRequest<IEnumerable<TopicResponse>>;
}
