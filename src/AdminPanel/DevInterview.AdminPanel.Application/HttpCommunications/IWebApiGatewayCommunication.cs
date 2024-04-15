using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.HttpCommunications.Responses;
using Refit;

namespace DevInterview.AdminPanel.Application.HttpCommunications
{
    public interface IWebApiGatewayCommunication
    {
        [Post("/api/login")]
        Task<LoginWebApiGatewayCommunicationResponse> Login([Body] LoginWebApiGatewayCommunicationRequest request);

        [Get("/api/subjects")]
        Task<List<SubjectWebApiGatewayCommunicationResponse>> GetSubjets();
    }
}