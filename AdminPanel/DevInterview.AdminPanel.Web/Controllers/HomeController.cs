using DevInterview.AdminPanel.Web.Models;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace DevInterview.AdminPanel.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FirebaseAuthProvider _authentication;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _authentication = new FirebaseAuthProvider(new FirebaseConfig("AIzaSyAMQnAATQawfwiQJeOCK9n07MmkIOQ_5MU"));
        }

        public IActionResult Index()
        {
            return View();
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