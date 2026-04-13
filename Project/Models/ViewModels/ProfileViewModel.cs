using Project.Models;

namespace Project.Models.ViewModels;

public class ProfileViewModel
{
    public User User { get; set; } = new();
    public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    public List<HistoryDetailsViewModel> History { get; set; } = new List<HistoryDetailsViewModel>();
}
