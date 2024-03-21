using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class CreateTopicViewModel
    {
        public TopicViewModel Topic { get; set; }

        public string SelectedRoleId { get; set; }

        public List<SubjectViewModel> SubjectList { get; set; } = new();
    }
}
