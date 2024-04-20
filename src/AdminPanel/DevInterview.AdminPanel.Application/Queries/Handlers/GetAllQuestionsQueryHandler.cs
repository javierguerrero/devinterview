using DevInterview.AdminPanel.Application.HttpCommunications;
using DevInterview.AdminPanel.Application.Responses;
using MediatR;

namespace DevInterview.AdminPanel.Application.Queries.Handlers
{
    public class GetAllQuestionsQueryHandler : IRequestHandler<GetAllQuestionsQuery, IEnumerable<QuestionResponse>>
    {
        private readonly IWebApiGatewayCommunication _webApiGatewayCommunication;

        public GetAllQuestionsQueryHandler(IWebApiGatewayCommunication webApiGatewayCommunication)
        {
            _webApiGatewayCommunication = webApiGatewayCommunication;
        }

        public async Task<IEnumerable<QuestionResponse>> Handle(GetAllQuestionsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var questions = new List<QuestionResponse>();

                var response = await _webApiGatewayCommunication.GetAllQuestions();

                foreach (var item in response)
                {
                    questions.Add(new QuestionResponse
                    {
                        Id = item.Id,
                        QuestionText = item.QuestionText,
                        AnswerText = item.AnswerText,
                        TopicId = item.TopicId
                    });
                }
                return questions;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}