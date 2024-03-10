using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Application.Queries;
using DevInterview.AdminPanel.Web.Models;
using Firebase.Auth;
using Firebase.Storage;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class RolesController : Controller
    {
        private readonly ILogger<RolesController> _logger;
        private readonly IMediator _mediator;


        //TODO: crear servicio Storage
        private static string ApiKey = "AIzaSyAMQnAATQawfwiQJeOCK9n07MmkIOQ_5MU";
        private static string Bucket = "devinterview-2aedb.appspot.com";
        private static string AuthEmail = "uploadfiles@devinterview.com";
        private static string AuthPassword = "z6273KEr93C!";

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
                var viewModel = new RolesIndexViewModel();
                viewModel.RoleList = await _mediator.Send(new GetAllRolesQuery());
                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Login", "Home");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var vm = new CreateRoleViewModel();
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateRoleViewModel vm, IFormFile Image)
        {
            string urlImage = string.Empty;

            if(Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    await Image.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    urlImage = await Upload(ms, $"{Guid.NewGuid()}.jpg");
                }
            }

            await _mediator.Send(new CreateRoleCommand(vm.Name, urlImage));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(string roleId)
        {
            var role = await _mediator.Send(new GetRoleQuery(roleId));
            var viewModel = new UpdateRoleViewModel
            {
                RoleId = roleId,
                Name = role.Name,
                Image = role.Image
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoleViewModel vm, IFormFile Image)
        {
            string urlImage = string.Empty;

            if (Image != null)
            {
                using (var ms = new MemoryStream())
                {
                    await Image.CopyToAsync(ms);
                    ms.Seek(0, SeekOrigin.Begin);
                    urlImage = await Upload(ms, $"{Guid.NewGuid()}.jpg");
                }
            }

            var response = await _mediator.Send(new UpdateRoleCommand(vm.RoleId, vm.Name, urlImage));
            return RedirectToAction("Index");
        }

        public async Task<JsonResult> Delete(string id)
        {
            return Json(await _mediator.Send(new DeleteRoleCommand(id)));
        }

        private async Task<string> Upload(MemoryStream stream, string filename)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var firebaseAuthLink = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // You can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(Bucket, new FirebaseStorageOptions { AuthTokenAsyncFactory = () => Task.FromResult(firebaseAuthLink.FirebaseToken), ThrowOnCancel = true })
                            .Child("images")
                            .Child(filename)
                            .PutAsync(stream, cancellation.Token);

            try
            {
                string link = await task;
                return link;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}