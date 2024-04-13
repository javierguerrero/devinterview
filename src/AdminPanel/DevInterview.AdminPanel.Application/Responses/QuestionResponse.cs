using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Responses
{
    public class QuestionResponse
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string TopicId { get; set; }
    }
}
