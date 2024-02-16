using DevInterview.AdminPanel.Application.Responses;

namespace DevInterview.AdminPanel.Web.Models
{
    public class TopicsIndexViewModel
    {
        public IEnumerable<TopicResponse> TopicList { get; set; } = new List<TopicResponse>();
    }
}
