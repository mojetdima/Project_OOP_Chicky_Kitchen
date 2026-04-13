using Microsoft.AspNetCore.Mvc;
using Project.Models.ViewModels;
using Project.Models;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new HomeViewModel
            {
                Headline = "Chicky Kitchen",
                WelcomeText = "Welcome to Chicky Kitchen, where crispy comfort food meets a warm restaurant atmosphere. We serve fresh chicken dishes, colorful drinks, and family-friendly dining in the heart of the city.",
                Slogans = new List<string>
                {
                    "Fresh crunch in every bite",
                    "The happiest table in town",
                    "Golden flavor, unforgettable moments"
                },
                Highlights = new List<string>
                {
                    "Signature chicken burgers and spicy wings",
                    "Fast online reservations for couples and families",
                    "Stylish interior and handcrafted desserts"
                }
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
