﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.HttpCommunications.Responses
{
    public class TopicWebApiGatewayCommunicationResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
    }
}
