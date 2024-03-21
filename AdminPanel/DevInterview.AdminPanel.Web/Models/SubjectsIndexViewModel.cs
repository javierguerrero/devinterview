using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class SubjectsIndexViewModel
    {
        public IEnumerable<SubjectResponse> SubjectList { get; set; } = new List<SubjectResponse>();
        public SubjectResponse Subject { get; set; }
    }
}