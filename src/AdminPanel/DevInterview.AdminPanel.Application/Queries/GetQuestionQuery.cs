using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetQuestionQuery(int questionId) : IRequest<QuestionResponse>;
}
