using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IMediator _mediator;

        public RolesController(ILogger<RolesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                var viewModel = new RolesViewModel();
                viewModel.RoleList = await _mediator.Send(new GetAllRolesQuery());
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }
    }
}