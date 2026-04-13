using Microsoft.AspNetCore.Mvc;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        var model = new ContactViewModel
        {
            Address = "15 Golden Fry Street, Warsaw, Poland",
            OpeningHours = "Mon-Sun: 11:00 - 23:00",
            Phones = ["+48 501 234 567", "+48 22 700 11 22"],
            Emails = ["hello@chickykitchen.com", "reservations@chickykitchen.com"]
        };

        return View(model);
    }
}
