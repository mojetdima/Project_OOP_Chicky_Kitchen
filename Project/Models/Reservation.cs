using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Reservation
{
    public int Id { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Range(1, 100)]
    public int TableNumber { get; set; }

    [Range(1, 20)]
    public int AmountOfGuests { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }
}
