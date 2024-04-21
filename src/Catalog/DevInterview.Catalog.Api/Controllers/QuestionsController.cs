using DevInterview.Catalog.Application.Commands;
using DevInterview.Catalog.Application.Queries;
using DevInterview.Catalog.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.Catalog.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QuestionsController> _logger;

        public QuestionsController(ILogger<QuestionsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(await _mediator.Send(new GetAllQuestionsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestion(int id)
        {
            var response = await _mediator.Send(new GetQuestionQuery(id));
            if (response is null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] CreateQuestionRequest question)
        {
            var response = await _mediator.Send(new CreateQuestionCommand(question.QuestionText, question.AnswerText, question.TopicId));

            return CreatedAtAction(nameof(GetQuestion), new { id = response.Id }, response);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutQuestion(int id, [FromBody] UpdateQuestionRequest question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            await _mediator.Send(new UpdateQuestionCommand(question.Id, question.QuestionText, question.AnswerText, question.TopicId));

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _mediator.Send(new DeleteQuestionCommand(id));
            if (result)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}