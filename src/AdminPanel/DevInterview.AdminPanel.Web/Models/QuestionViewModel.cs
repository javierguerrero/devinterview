namespace DevInterview.AdminPanel.Web.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int TopicId { get; set; }
        public string TopicName { get; set; }
    }
}




