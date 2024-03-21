using AutoMapper;
using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Google.Rpc.Context.AttributeContext.Types;

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
                var topics = await _mediator.Send(new GetAllTopicsQuery());
                var vm = new TopicsIndexViewModel
                {
                    TopicList = _mapper.Map<List<TopicViewModel>>(topics)
                };

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
            var roles = await _mediator.Send(new GetAllSubjectsQuery());
            var vm = new CreateTopicViewModel
            {
                SubjectList = _mapper.Map<List<SubjectViewModel>>(roles)
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
        public async Task<IActionResult> Update(string topicId)
        {
            var topic = await _mediator.Send(new GetTopicQuery(topicId));
            var roles = await _mediator.Send(new GetAllSubjectsQuery());

            var vm = new UpdateTopicViewModel();
            vm.Topic = _mapper.Map<TopicViewModel>(topic);
            vm.RoleList = _mapper.Map<List<SubjectViewModel>>(roles);

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTopicViewModel vm)
        {
            await _mediator.Send(new UpdateTopicCommand(vm.Topic.TopicId, vm.Topic.Name, vm.Topic.Description, vm.SelectedRoleId));
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete(string id)
        {
            return Json(await _mediator.Send(new DeleteTopicCommand(id)));
        }

        [HttpGet]
        public async Task<JsonResult> GetTopicsBySubject(string subjectId)
        {
            var topics = await GetTopics(subjectId);
            return Json(topics);
        }

        private async Task<List<SelectListItem>> GetTopics(string subjectId)
        {
            var results = new List<SelectListItem>();
            var data = await _mediator.Send(new GetTopicsByRoleQuery(subjectId));
            foreach (var topic in data)
            {
                results.Add(new SelectListItem
                {
                    Text = topic.Name,
                    Value = topic.TopicId
                });
            }

            return results;
        }
    }
}