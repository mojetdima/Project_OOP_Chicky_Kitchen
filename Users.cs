public class User
{
    public int Id { get; set; }

    public string Login { get; set; }
    public string Password { get; set; } 
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public List<Reservation> Reservations { get; set; }
    public List<History> Histories { get; set; }
}