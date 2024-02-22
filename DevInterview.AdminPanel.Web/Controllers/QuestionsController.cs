using AutoMapper;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ILogger<QuestionsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public QuestionsController(ILogger<QuestionsController> logger, IMediator mediator, IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                var vm = new QuestionsIndexViewModel();
                var response = await _mediator.Send(new GetAllQuestionsQuery());
                vm.QuestionList = _mapper.Map<List<QuestionViewModel>>(response);
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}