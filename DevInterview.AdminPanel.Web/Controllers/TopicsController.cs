using AutoMapper;
using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ILogger<TopicsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public TopicsController(ILogger<TopicsController> logger, IMediator mediator, IMapper mapper)
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
                var vm = new TopicsIndexViewModel();
                var response = await _mediator.Send(new GetAllTopicsQuery());
                vm.TopicList = _mapper.Map<List<TopicViewModel>>(response);
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
            var vm = new CreateTopicViewModel();
            var response = await _mediator.Send(new GetAllRolesQuery());
            vm.RoleList = _mapper.Map<List<RoleViewModel>>(response);
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTopicViewModel vm)
        {
            await _mediator.Send(new CreateTopicCommand(vm.Topic.Name, vm.Topic.Description, vm.SelectedRoleId));
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete(string id)
        {
            return Json(await _mediator.Send(new DeleteTopicCommand(id)));
        }
    }
}