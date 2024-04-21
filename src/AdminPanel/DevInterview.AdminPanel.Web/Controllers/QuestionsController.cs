using AutoMapper;
using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Google.Rpc.Context.AttributeContext.Types;

namespace DevInterview.AdminPanel.Web.Controllers
{
    [Authorize]
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
            var questions = await _mediator.Send(new GetAllQuestionsQuery());
            var vm = new QuestionsIndexViewModel
            {
                QuestionList = _mapper.Map<List<QuestionViewModel>>(questions)
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var roles = await _mediator.Send(new GetAllSubjectsQuery());
            var vm = new CreateQuestionViewModel
            {
                SubjectList = _mapper.Map<List<SubjectViewModel>>(roles)
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionViewModel vm)
        {
            await _mediator.Send(new CreateQuestionCommand(vm.Question.QuestionText, vm.Question.AnswerText, vm.SelectedTopicId));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int questionId)
        {
            var question = await _mediator.Send(new GetQuestionQuery(questionId));

            var subjects = await _mediator.Send(new GetAllSubjectsQuery());
            var topics = await _mediator.Send(new GetTopicsBySubjectQuery(question.SubjectId));

            var vm = new UpdateQuestionViewModel
            {
                SubjectList = _mapper.Map<List<SubjectViewModel>>(subjects),
                TopicList = _mapper.Map<List<TopicViewModel>>(topics),
                Question = _mapper.Map<QuestionViewModel>(question),
                SelectedSubjectId = question.SubjectId,
                SelectedTopicId = question.TopicId
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateQuestionViewModel vm)
        {
            await _mediator.Send(new UpdateQuestionCommand(vm.Question.Id, vm.Question.QuestionText, vm.Question.AnswerText, vm.SelectedTopicId));
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<JsonResult> GetQuestionsByTopic(string topicId)
        {
            var data = await _mediator.Send(new GetQuestionsByTopicQuery(topicId));
            return Json(data);
        }

        public async Task<JsonResult> Delete(int id)
        {
            return Json(await _mediator.Send(new DeleteQuestionCommand(id)));
        }
    }
}