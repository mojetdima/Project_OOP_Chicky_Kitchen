using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Menu
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string DishName { get; set; } = string.Empty;

    [Range(1, 1000)]
    public decimal Price { get; set; }

    [Required]
    [StringLength(300)]
    public string Compound { get; set; } = string.Empty;

    public List<History> Histories { get; set; } = [];
}
