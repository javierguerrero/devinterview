namespace DevInterview.Catalog.Application.Responses
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int TopicId { get; set; }
        public int SubjectId { get; set; }
    }
}