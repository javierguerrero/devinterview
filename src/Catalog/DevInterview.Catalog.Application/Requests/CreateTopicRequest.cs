namespace DevInterview.Catalog.Application.Requests
{
    public class CreateTopicRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
    }
}