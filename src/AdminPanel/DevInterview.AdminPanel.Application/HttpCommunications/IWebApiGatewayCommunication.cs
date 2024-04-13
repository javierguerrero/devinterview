using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.HttpCommunications.Responses;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.HttpCommunications
{
    public interface IWebApiGatewayCommunication
    {
        [Post("/api/login")]
        Task<LoginWebApiGatewayCommunicationResponse> Login([Body] LoginWebApiGatewayCommunicationRequest request);
    }
}
