using DevInterview.Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Route("[action]")]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(await _mediator.Send(new GetAllQuestionsQuery()));
        }
    }
}