using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class CreateQuestionViewModel
    {
        public QuestionViewModel Question { get; set; }
        public List<SubjectViewModel> SubjectList { get; set; } = new();
        public int SelectedSubjectId { get; set; }
        public int SelectedTopicId { get; set; }
    }
}
