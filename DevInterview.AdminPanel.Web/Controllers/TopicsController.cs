using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class TopicsController : Controller
    {
        private readonly ILogger<TopicsController> _logger;
        private readonly IMediator _mediator;

        public TopicsController(ILogger<TopicsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                //var viewModel = new RolesIndexViewModel();
                //viewModel.RoleList = await _mediator.Send(new GetAllRolesQuery());
                //return View(viewModel);

                return View(null);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateTopicViewModel vm)
        {
            return View();
        }


    }
}