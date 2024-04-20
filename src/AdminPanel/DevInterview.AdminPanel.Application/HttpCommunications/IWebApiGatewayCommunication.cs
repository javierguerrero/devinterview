using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.HttpCommunications.Responses;
using Refit;

namespace DevInterview.AdminPanel.Application.HttpCommunications
{
    //https://code-maze.com/using-refit-to-consume-apis-in-csharp/

    public interface IWebApiGatewayCommunication
    {
        #region auth
        [Post("/api/login")]
        Task<LoginWebApiGatewayCommunicationResponse> Login([Body] LoginWebApiGatewayCommunicationRequest request);
        #endregion

        #region subjects

        [Get("/api/subjects")]
        Task<List<SubjectWebApiGatewayCommunicationResponse>> GetAllSubjects();

        [Get("/api/subjects/{id}")]
        Task<SubjectWebApiGatewayCommunicationResponse> GetSubject(int id);

        [Post("/api/subjects")]
        Task<SubjectWebApiGatewayCommunicationResponse> CreateSubject([Body] SubjectWebApiGatewayCommunicationRequest request);

        [Put("/api/subjects/{id}")]
        Task UpdateSubject(int id, [Body] SubjectWebApiGatewayCommunicationRequest request);

        [Delete("/api/subjects/{id}")]
        Task DeleteSubject(int id);

        #endregion


        #region topics
        [Get("/api/topics")]
        Task<List<TopicWebApiGatewayCommunicationResponse>> GetAllTopics();

        [Delete("/api/topics/{id}")]
        Task DeleteTopic(int id);
        #endregion
    }
}