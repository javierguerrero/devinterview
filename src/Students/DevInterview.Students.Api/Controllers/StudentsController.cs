using DevInterview.Students.Application.Commands;
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
            //var response = await _mediator.Send(new GetSubjectQuery(id));
            //if (response is null)
            //{
            //    return NotFound();
            //}
            //return Ok(response);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostSubject([FromBody] CreateStudentRequest student)
        {
            var response = await _mediator.Send(new CreateStudentCommand(student.UserName, student.FirstName, student.LastName));

            return CreatedAtAction(nameof(GetSubject), new { id = response.Id }, response);
        }
    }
}