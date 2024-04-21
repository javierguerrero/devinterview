using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.HttpCommunications.Responses;
using Refit;

namespace DevInterview.AdminPanel.Application.HttpCommunications
{
    //https://code-maze.com/using-refit-to-consume-apis-in-csharp/

    public interface IWebApiGatewayCommunication
    {
        #region Auth

        [Post("/api/login")]
        Task<LoginWebApiGatewayCommunicationResponse> Login([Body] LoginWebApiGatewayCommunicationRequest request);

        #endregion Auth

        #region Subjects

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

        #endregion Subjects

        #region Topics

        [Get("/api/topics")]
        Task<List<TopicWebApiGatewayCommunicationResponse>> GetAllTopics();

        [Get("/api/topics/{id}")]
        Task<TopicWebApiGatewayCommunicationResponse> GetTopic(int id);

        [Post("/api/topics")]
        Task<TopicWebApiGatewayCommunicationResponse> CreateTopic([Body] TopicWebApiGatewayCommunicationRequest request);

        [Put("/api/topics/{id}")]
        Task UpdateTopic(int id, [Body] TopicWebApiGatewayCommunicationRequest request);

        [Delete("/api/topics/{id}")]
        Task DeleteTopic(int id);

        [Get("/api/subjects/{id}/topics")]
        Task<List<TopicWebApiGatewayCommunicationResponse>> GetTopicsBySubject(int id);

        #endregion Topics

        #region Questions

        [Get("/api/questions")]
        Task<List<QuestionWebApiGatewayCommunicationResponse>> GetAllQuestions();

        [Get("/api/questions/{id}")]
        Task<QuestionWebApiGatewayCommunicationResponse> GetQuestion(int id);

        [Post("/api/questions")]
        Task<QuestionWebApiGatewayCommunicationResponse> CreateQuestion([Body] QuestionWebApiGatewayCommunicationRequest request);

        [Put("/api/questions/{id}")]
        Task UpdateQuestion(int id, [Body] QuestionWebApiGatewayCommunicationRequest request);

        [Delete("/api/questions/{id}")]
        Task DeleteQuestion(int id);

        #endregion Questions
    }
}