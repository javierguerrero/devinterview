
using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DDevInterview.Catalog.Application.Queries
{
    public record GetQuestionQuery(int questionId) : IRequest<QuestionResponse>;
}
