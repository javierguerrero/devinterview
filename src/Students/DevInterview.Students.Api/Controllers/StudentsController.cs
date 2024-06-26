﻿using DevInterview.Students.Application.Commands;
using DevInterview.Students.Application.Queries;
using DevInterview.Students.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.Students.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var response = await _mediator.Send(new GetStudentQuery(id));
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSubject([FromBody] CreateStudentRequest student)
        {
            var response = await _mediator.Send(new CreateStudentCommand(
                                                            student.UserName, 
                                                            student.FirstName, 
                                                            student.LastName, 
                                                            student.Password, 
                                                            student.Role
                                                            ));

            return CreatedAtAction(nameof(GetSubject), new { id = response.Id }, response);
        }
    }
}