using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DevInterview.MobileApp.Models
{
    public class Question
    {
        public string Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public string TopicId { get; set; }
        public int Number { get; set; }
        public string Title => $"{Number}. {QuestionText}";
    }

}