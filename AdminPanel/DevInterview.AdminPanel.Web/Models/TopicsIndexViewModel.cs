using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class TopicsIndexViewModel
    {
        public List<TopicViewModel> TopicList { get; set; } = new();
        public List<RoleViewModel> RoleList { get; set; } = new();
    }
}
