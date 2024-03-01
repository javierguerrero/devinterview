using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class UpdateQuestionViewModel
    {
        public QuestionViewModel Question { get; set; }

        public string SelectedTopicId { get; set; }

        public List<TopicViewModel> TopicList { get; set; } = new();
    }
}
