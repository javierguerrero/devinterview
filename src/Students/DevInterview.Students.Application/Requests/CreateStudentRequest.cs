﻿namespace DevInterview.Students.Application.Requests
{
    public class CreateStudentRequest
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Password { get; set; }
        public string Role { get; set; }
    }
}