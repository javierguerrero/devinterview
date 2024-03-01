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

        [HttpPost]
        public async Task<IActionResult> Create(string questionText, string answerText, string topicId)
        {
            await _mediator.Send(new CreateQuestionCommand(questionText, answerText, topicId));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string questionId, string roleId)
        {
            var question = await _mediator.Send(new GetQuestionQuery(questionId));
            var topics = await _mediator.Send(new GetTopicsByRoleQuery(roleId));

            var vm = new UpdateQuestionViewModel
            {
                Question = _mapper.Map<QuestionViewModel>(question),
                TopicList = _mapper.Map<List<TopicViewModel>>(topics),
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionsByTopic(string topicId)
        {
            var data = await _mediator.Send(new GetQuestionsByTopicQuery(topicId));
            return Json(data);
        }

        public async Task<JsonResult> Delete(string id)
        {
            return Json(await _mediator.Send(new DeleteQuestionCommand(id)));
        }
    }
}