using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DevInterview.Catalog.Application.Queries
{
    public record GetAllQuestionsQuery : IRequest<IEnumerable<QuestionResponse>>;
}
