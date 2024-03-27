using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.Catalog.Application.Requests
{
    public class CreateQuestionRequest
    {
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int TopicId { get; set; }
    }
}
