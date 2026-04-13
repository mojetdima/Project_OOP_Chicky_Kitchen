public class History
{
    public int Id { get; set; }

    public int TableNumber { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int MenuId { get; set; }
    public Menu Menu { get; set; }
}