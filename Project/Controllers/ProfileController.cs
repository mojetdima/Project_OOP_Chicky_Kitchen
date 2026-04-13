using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class ProfileController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var login = HttpContext.Session.GetString("UserLogin");
        User? user = null;
        if (!string.IsNullOrEmpty(login))
        {
            user = await dbContext.Users
                .Include(u => u.Reservations)
                .Include(u => u.Histories)
                .ThenInclude(h => h.Menu)
                .FirstOrDefaultAsync(u => u.Login == login);
        }

        var model = new ProfileViewModel();
        if (user is not null)
        {
            model.User = user;
            model.Reservations = user.Reservations.OrderBy(r => r.Date).ToList();
            model.History = user.Histories
                .Select(h => new HistoryDetailsViewModel
                {
                    DishName = h.Menu?.DishName ?? "Unknown dish",
                    TableNumber = h.TableNumber
                })
                .ToList();
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult CreateReservation()
    {
        return View(new ReservationCreateViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateReservation(ReservationCreateViewModel model)
    {
        var login = HttpContext.Session.GetString("UserLogin");
        var user = string.IsNullOrEmpty(login) ? null : await dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "You must be logged in to create a reservation.");
        }

        if (!ModelState.IsValid || user is null)
        {
            return View(model);
        }

        dbContext.Reservations.Add(new Reservation
        {
            Date = model.Date,
            TableNumber = model.TableNumber,
            AmountOfGuests = model.AmountOfGuests,
            UserId = user.Id
        });

        await dbContext.SaveChangesAsync();
        TempData["SuccessMessage"] = "Reservation created successfully.";
        return RedirectToAction(nameof(Index));
    }
}
