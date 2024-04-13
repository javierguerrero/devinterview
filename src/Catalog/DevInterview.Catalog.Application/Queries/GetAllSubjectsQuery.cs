
using DevInterview.Catalog.Application.Responses;
using MediatR;

namespace DevInterview.Catalog.Application.Queries
{
    public record GetAllSubjectsQuery : IRequest<IEnumerable<SubjectResponse>>;
}
