using DevInterview.AdminPanel.Application.Commands;
using DevInterview.AdminPanel.Web.Models;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            try
            {
                var response = await _mediator.Send(new LoginCommand(vm.Username, vm.Password));

                //save the token to a session variable
                if (response.Token != null)
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, vm.Username),
                };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(String.Empty, ex.Message);
                return View(vm);
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}