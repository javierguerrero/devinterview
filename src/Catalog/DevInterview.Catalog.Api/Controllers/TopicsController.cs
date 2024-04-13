using DevInterview.Catalog.Application.Commands;
using DevInterview.Catalog.Application.Queries;
using DevInterview.Catalog.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TopicsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<TopicsController> _logger;

        public TopicsController(ILogger<TopicsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            return Ok(await _mediator.Send(new GetAllTopicsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopic(int id)
        {
            var response = await _mediator.Send(new GetTopicQuery(id));
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTopic([FromBody] CreateTopicRequest topic)
        {
            var response = await _mediator.Send(new CreateTopicCommand(topic.Name, topic.Description, topic.SubjectId));

            return CreatedAtAction(nameof(GetTopic), new { id = response.Id }, response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutTopic(int id, [FromBody] UpdateTopicRequest topic)
        {
            if (id != topic.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateTopicCommand(topic.Id, topic.Name, topic.Description, topic.SubjectId));

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var result = await _mediator.Send(new DeleteTopicCommand(id));
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{topicId}/questions")]
        public async Task<IActionResult> GetQuestionsByTopic(int topicId)
        {
            return Ok(await _mediator.Send(new GetQuestionsByTopicQuery(topicId)));
        }
    }
}