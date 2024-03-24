using DevInterview.Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Route("[action]")]
        public async Task<IActionResult> GetAllTopics()
        {
            return Ok(await _mediator.Send(new GetAllTopicsQuery()));
        }
    }
}