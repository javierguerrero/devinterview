using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class UpdateTopicViewModel
    {
        public TopicViewModel Topic { get; set; }

        public string SelectedRoleId { get; set; }

        public List<SubjectViewModel> RoleList { get; set; } = new();
    }
}
