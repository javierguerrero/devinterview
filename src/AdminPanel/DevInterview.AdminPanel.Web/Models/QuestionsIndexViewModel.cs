namespace DevInterview.AdminPanel.Web.Models
{
    public class QuestionsIndexViewModel
    {
        public string SelectedSubjectId { get; set; }
        public string SelectedTopicId { get; set; }
        public List<SubjectViewModel> SubjectList { get; set; } = new();
        public QuestionViewModel Question { get; set; }

        public List<QuestionViewModel> QuestionList { get; set; } = new();
    }
}
