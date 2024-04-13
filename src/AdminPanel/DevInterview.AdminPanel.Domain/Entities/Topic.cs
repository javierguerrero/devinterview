using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Domain.Entities
{
    public class Topic
    {
        public string TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
