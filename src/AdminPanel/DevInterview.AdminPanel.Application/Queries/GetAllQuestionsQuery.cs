using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries
{
    public record GetAllQuestionsQuery : IRequest<IEnumerable<QuestionResponse>>;
}
