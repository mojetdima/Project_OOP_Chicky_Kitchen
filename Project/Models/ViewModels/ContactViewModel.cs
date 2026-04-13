namespace Project.Models.ViewModels;

public class ContactViewModel
{
    public string Address { get; set; } = string.Empty;
    public List<string> Phones { get; set; } = [];
    public List<string> Emails { get; set; } = [];
    public string OpeningHours { get; set; } = string.Empty;
}
