public class Menu
{
    public int Id { get; set; }

    public string DishName { get; set; }
    public int Price { get; set; }
    public string Compound { get; set; } 

    public List<History> Histories { get; set; }
}