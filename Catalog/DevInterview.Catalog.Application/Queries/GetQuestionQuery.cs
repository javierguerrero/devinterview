using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DevInterview.Catalog.Application.Queries
{
    public record GetQuestionQuery(int questionId) : IRequest<QuestionResponse>;
}
