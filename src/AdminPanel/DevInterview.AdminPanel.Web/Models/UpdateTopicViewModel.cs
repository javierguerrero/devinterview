using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class UpdateTopicViewModel
    {
        public TopicViewModel Topic { get; set; }
        public List<SubjectViewModel> SubjectList { get; set; } = new();
        public int SelectedSubjectId { get; set; }
    }
}
