using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.HttpCommunications.Requests
{
    public class LoginWebApiGatewayCommunicationRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
