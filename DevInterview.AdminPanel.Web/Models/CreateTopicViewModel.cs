using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class CreateTopicViewModel
    {
        public string Name { get; set; }

        public string SelectedRoleId { get; set; }
        public IEnumerable<RoleResponse> RoleList { get; set; } = new List<RoleResponse>();
    }
}
