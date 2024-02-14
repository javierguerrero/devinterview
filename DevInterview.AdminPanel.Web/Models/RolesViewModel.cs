using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class RolesViewModel
    {
        public IEnumerable<RoleResponse> RoleList { get; set; } = new List<RoleResponse>();
        public RoleResponse Role { get; set; }
    }
}
