namespace DevInterview.AdminPanel.Application.HttpCommunications.Requests
{
    public class TopicWebApiGatewayCommunicationRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
    }
}
