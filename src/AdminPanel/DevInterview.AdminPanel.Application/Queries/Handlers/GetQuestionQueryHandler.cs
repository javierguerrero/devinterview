using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, QuestionResponse>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetQuestionQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<QuestionResponse> Handle(GetQuestionQuery request, CancellationToken cancellationToken)
        {
            var response = await _webApiGatewayCommunication.GetQuestion(request.questionId);
            var question = new QuestionResponse
            {
                Id = response.Id,
                QuestionText = response.QuestionText,
                AnswerText = response.AnswerText,
                TopicId = response.TopicId
            };
            return question;
        }
    }
}