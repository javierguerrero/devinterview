﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevInterview.AdminPanel.Application.Responses
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}
