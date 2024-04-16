using DevInterview.Catalog.Application.Commands;
using DevInterview.Catalog.Application.Queries;
using DevInterview.Catalog.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<SubjectsController> _logger;

        public SubjectsController(ILogger<SubjectsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSubjects()
        {
            return Ok(await _mediator.Send(new GetAllSubjectsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubject(int id)
        {
            var response = await _mediator.Send(new GetSubjectQuery(id));
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostSubject([FromBody] CreateSubjectRequest subject)
        {
            var response = await _mediator.Send(new CreateSubjectCommand(subject.Name, subject.Image));

            return CreatedAtAction(nameof(GetSubject), new { id = response.Id }, response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutSubject(int id, [FromBody] UpdateSubjectRequest subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateSubjectCommand(subject.Id, subject.Name, subject.Image));

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var result = await _mediator.Send(new DeleteSubjectCommand(id));
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{subjectId}/topics")]
        public async Task<IActionResult> GetTopicsBySubjectId(int subjectId)
        {
            var response = await _mediator.Send(new GetTopicsBySubjectQuery(subjectId));
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }
    }
}