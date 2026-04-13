using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;

namespace Project.Controllers;

public class MenuController(ApplicationDbContext dbContext) : Controller
{
    public async Task<IActionResult> Index()
    {
        var menuItems = await dbContext.Menus
            .OrderBy(item => item.DishName)
            .ToListAsync();

        return View(menuItems);
    }
}
