using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Responses
{
    public class QuestionResponse
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
