using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class CreateTopicViewModel
    {
        public TopicViewModel Topic { get; set; }
        public List<SubjectViewModel> SubjectList { get; set; } = new();
        public int SelectedSubjectId { get; set; }
    }
}
