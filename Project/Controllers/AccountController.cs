using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class AccountController(ApplicationDbContext dbContext) : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await dbContext.Users
            .FirstOrDefaultAsync(u => u.Login == model.Login && u.Password == model.Password);

        if (user is null)
        {
            ModelState.AddModelError(string.Empty, "Invalid login or password.");
            return View(model);
        }

        // Set simple session-based login
        HttpContext.Session.SetString("UserLogin", user.Login);
        TempData["SuccessMessage"] = $"Welcome back, {user.Name}.";
        return RedirectToAction("Index", "Profile");
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var loginExists = await dbContext.Users.AnyAsync(u => u.Login == model.Login);
        if (loginExists)
        {
            ModelState.AddModelError(nameof(model.Login), "This login is already taken.");
            return View(model);
        }

        var emailExists = await dbContext.Users.AnyAsync(u => u.Email == model.Email);
        if (emailExists)
        {
            ModelState.AddModelError(nameof(model.Email), "This email is already registered.");
            return View(model);
        }

        dbContext.Users.Add(new User
        {
            Login = model.Login,
            Password = model.Password,
            Name = model.Name,
            Surname = model.Surname,
            Age = model.Age,
            Email = model.Email
        });

        await dbContext.SaveChangesAsync();
        // Set session to the newly registered user
        HttpContext.Session.SetString("UserLogin", model.Login);
        TempData["SuccessMessage"] = "Registration completed. You can now view your profile.";
        return RedirectToAction("Index", "Profile");
    }
}
