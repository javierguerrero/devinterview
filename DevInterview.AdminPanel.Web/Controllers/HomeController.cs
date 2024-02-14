using DevInterview.AdminPanel.Web.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DevInterview.AdminPanel.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FirebaseAuthProvider _authentication;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _authentication = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAMQnAATQawfwiQJeOCK9n07MmkIOQ_5MU"));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                //log in an existing user
                var fbAuthLink = await _authentication.SignInWithEmailAndPasswordAsync(login.Email, login.Password);
                string token = fbAuthLink.FirebaseToken;

                //save the token to a session variable
                if (token != null)
                {
                    HttpContext.Session.SetString("_UserToken", token);

                    return RedirectToAction("Index");
                }
            }
            catch (FirebaseAuthException ex)
            {
                var firebaseEx = JsonConvert.DeserializeObject<FirebaseErrorViewModel>(ex.ResponseData);
                ModelState.AddModelError(String.Empty, firebaseEx.error.message);
                return View(login);
            }

            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("_UserToken");
            return RedirectToAction("Login");
        }

        public IActionResult Index()
        {
            var token = HttpContext.Session.GetString("_UserToken");

            if (token != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }

            //return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}