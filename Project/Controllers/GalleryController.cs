using Microsoft.AspNetCore.Mvc;
using Project.Models.ViewModels;

namespace Project.Controllers;

public class GalleryController : Controller
{
    public IActionResult Index()
    {
        var items = new List<GalleryItemViewModel>
        {
            new()
            {
                Title = "Signature Burger",
                Description = "Crunchy chicken with fresh vegetables and creamy sauce.",
                ImageUrl = "https://images.unsplash.com/photo-1562967916-eb82221dfb92?auto=format&fit=crop&w=900&q=80"
            },
            new()
            {
                Title = "Hot Wings",
                Description = "Sweet, spicy and glazed wings served fresh from the kitchen.",
                ImageUrl = "https://images.unsplash.com/photo-1527477396000-e27163b481c2?auto=format&fit=crop&w=900&q=80"
            },
            new()
            {
                Title = "Dessert Corner",
                Description = "Chocolate, berries and a soft finish after dinner.",
                ImageUrl = "https://images.unsplash.com/photo-1551024601-bec78aea704b?auto=format&fit=crop&w=900&q=80"
            },
            new()
            {
                Title = "Fresh Lemonade",
                Description = "A bright and cooling drink for every menu set.",
                ImageUrl = "https://images.unsplash.com/photo-1513558161293-cdaf765ed2fd?auto=format&fit=crop&w=900&q=80"
            }
        };

        return View(items);
    }
}
