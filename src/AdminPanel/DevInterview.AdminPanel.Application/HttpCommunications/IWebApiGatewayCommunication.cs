using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.HttpCommunications.Responses;
using Refit;

namespace DevInterview.AdminPanel.Application.HttpCommunications
{
    //https://code-maze.com/using-refit-to-consume-apis-in-csharp/

    public interface IWebApiGatewayCommunication
    {
        [Post("/api/login")]
        Task<LoginWebApiGatewayCommunicationResponse> Login([Body] LoginWebApiGatewayCommunicationRequest request);

        [Get("/api/subjects")]
        Task<List<SubjectWebApiGatewayCommunicationResponse>> GetSubjects();

        [Delete("/api/subjects/{id}")]
        Task DeleteSubject(int id);
    }
}