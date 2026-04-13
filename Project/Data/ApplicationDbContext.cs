using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Reservation> Reservations => Set<Reservation>();
    public DbSet<Menu> Menus => Set<Menu>();
    public DbSet<History> Histories => Set<History>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Login)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Menu>().HasData(
            new Menu { Id = 1, DishName = "Crispy Chicken Burger", Price = 29, Compound = "Chicken fillet, brioche bun, cheddar, lettuce, tomato, house sauce" },
            new Menu { Id = 2, DishName = "Golden Wings Bucket", Price = 39, Compound = "Spicy wings, barbecue glaze, ranch dip, herbs" },
            new Menu { Id = 3, DishName = "Kitchen Signature Wrap", Price = 27, Compound = "Grilled chicken, tortilla, fresh vegetables, garlic sauce" },
            new Menu { Id = 4, DishName = "Sunrise Lemonade", Price = 12, Compound = "Lemon, orange, mint, sparkling water" },
            new Menu { Id = 5, DishName = "Chocolate Lava Cake", Price = 18, Compound = "Warm chocolate cake, vanilla ice cream, berries" }
        );

        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = 1,
                Login = "anna",
                Password = "anna123",
                Name = "Anna",
                Surname = "Nowak",
                Age = 26,
                Email = "anna@chickykitchen.com"
            }
        );

        modelBuilder.Entity<Reservation>().HasData(
            new Reservation
            {
                Id = 1,
                Date = new DateTime(2026, 4, 18, 19, 0, 0),
                TableNumber = 5,
                AmountOfGuests = 3,
                UserId = 1
            },
            new Reservation
            {
                Id = 2,
                Date = new DateTime(2026, 4, 23, 20, 30, 0),
                TableNumber = 2,
                AmountOfGuests = 2,
                UserId = 1
            }
        );

        modelBuilder.Entity<History>().HasData(
            new History { Id = 1, UserId = 1, MenuId = 1, TableNumber = 5 },
            new History { Id = 2, UserId = 1, MenuId = 5, TableNumber = 5 },
            new History { Id = 3, UserId = 1, MenuId = 2, TableNumber = 2 }
        );
    }
}
