using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.HttpCommunications.Responses
{
    public class LoginWebApiGatewayCommunicationResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
