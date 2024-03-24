using DevInterview.Catalog.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        [Route("[action]")]
        public async Task<IActionResult> GetAllSubjects()
        {
            return Ok(await _mediator.Send(new GetAllSubjectsQuery()));
        }
    }
}