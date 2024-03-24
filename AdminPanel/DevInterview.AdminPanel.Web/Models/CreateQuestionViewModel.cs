using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class CreateQuestionViewModel
    {
        public QuestionViewModel Question { get; set; }

        public string SelectedSubjectId { get; set; }

        public string SelectedTopicId { get; set; }

        public List<SubjectViewModel> SubjectList { get; set; } = new();
    }
}
