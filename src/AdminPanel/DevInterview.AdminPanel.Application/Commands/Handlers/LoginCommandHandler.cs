using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.HttpCommunications.Requests;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Commands.Handlers
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public LoginCommandHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _webApiGatewayCommunication.Login(new LoginWebApiGatewayCommunicationRequest { Username = request.username, Password = request.password });

                var loginResponse = new LoginResponse
                {
                    Token = response.Token,
                    Expiration = response.Expiration,
                };
                return loginResponse;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}