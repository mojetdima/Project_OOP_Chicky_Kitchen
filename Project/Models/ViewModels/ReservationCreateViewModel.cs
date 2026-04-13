using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels;

public class ReservationCreateViewModel
{
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime Date { get; set; } = DateTime.Today.AddDays(1).AddHours(18);

    [Range(1, 100)]
    public int TableNumber { get; set; }

    [Range(1, 20)]
    public int AmountOfGuests { get; set; }
}
