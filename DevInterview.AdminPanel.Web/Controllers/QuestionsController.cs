using AutoMapper;
using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
                var response = await _mediator.Send(new GetAllRolesQuery());
                vm.RoleList = _mapper.Map<List<RoleViewModel>>(response);
                return View(vm);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _mediator.Send(new GetAllRolesQuery());
            var vm = new CreateTopicViewModel
            {
                RoleList = _mapper.Map<List<RoleViewModel>>(roles)
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicViewModel vm)
        {
            await _mediator.Send(new CreateTopicCommand(vm.Topic.Name, vm.Topic.Description, vm.SelectedRoleId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionsByTopic(string topicId)
        {
            var data = await _mediator.Send(new GetQuestionsByTopicQuery(topicId));
            return Json(data);
        }
    }
}