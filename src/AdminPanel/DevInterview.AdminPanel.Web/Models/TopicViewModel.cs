using System.ComponentModel.DataAnnotations;

namespace DevInterview.AdminPanel.Web.Models
{
    public class TopicViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SubjectId { get; set; }

        public string SubjectName { get; set; }
    }
}