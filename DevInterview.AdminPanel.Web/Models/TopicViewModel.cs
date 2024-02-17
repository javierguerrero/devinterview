using System.ComponentModel.DataAnnotations;

namespace DevInterview.AdminPanel.Web.Models
{
    public class TopicViewModel
    {
        public string? TopicId { get; set; }

        //[Required]
        public string Name { get; set; }

        ///[Required]
        public string Description { get; set; }

    }
}
 