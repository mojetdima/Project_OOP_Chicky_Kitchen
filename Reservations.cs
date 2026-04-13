public class Reservation
{
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public int TableNumber { get; set; }
    public int AmountOfGuests { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
}