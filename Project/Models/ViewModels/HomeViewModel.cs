namespace Project.Models.ViewModels;

public class HomeViewModel
{
    public string Headline { get; set; } = string.Empty;
    public string WelcomeText { get; set; } = string.Empty;
    public List<string> Slogans { get; set; } = new List<string>();
    public List<string> Highlights { get; set; } = new List<string>();
}
