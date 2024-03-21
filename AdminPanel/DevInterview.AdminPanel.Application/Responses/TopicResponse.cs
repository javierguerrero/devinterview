﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Responses
{
    public class TopicResponse
    {
        public string TopicId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SubjectId { get; set; }

        public string SubjectName { get; set; }
    }
}
