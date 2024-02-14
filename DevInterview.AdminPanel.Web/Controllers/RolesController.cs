using DevInterview.AdminPanel.Application.Commands;
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

        [HttpPost]
        public async Task<IActionResult> Create(IList<IFormFile> files, string name)
        {
            string urlImage = string.Empty;

            if (files.Count > 0 && files[0].Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await files[0].CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    //urlImage = await Upload(ms, $"{Guid.NewGuid().ToString()}.jpg");
                }
            }

            await _mediator.Send(new CreateRoleCommand(name, urlImage));

            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete(string id)
        {
            return Json(await _mediator.Send(new DeleteRoleCommand(id)));
        }
    }
}