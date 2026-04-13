using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string Login { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Password { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string Surname { get; set; } = string.Empty;

    [Range(16, 120)]
    public int Age { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public List<Reservation> Reservations { get; set; } = [];
    public List<History> Histories { get; set; } = [];
}
