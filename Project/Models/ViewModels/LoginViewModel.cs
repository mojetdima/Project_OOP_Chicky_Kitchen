using System.ComponentModel.DataAnnotations;

namespace Project.Models.ViewModels;

public class LoginViewModel
{
    [Required]
    public string Login { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
