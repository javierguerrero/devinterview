using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Domain.Entities
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string TopicId { get; set; }
    }
}
