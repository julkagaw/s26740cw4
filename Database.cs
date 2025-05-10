using s26740cw4.Models;

namespace s26740cw4;

public static class Database
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal { Id = 1, Name = "Reksio", Category = "Pies", Weight = 12.5f, FurColor = "Brązowy" },
        new Animal { Id = 2, Name = "Mruczek", Category = "Kot", Weight = 4.2f, FurColor = "Szary" }
    };

    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit { Id = 1, AnimalId = 1, Date = DateTime.Now.AddDays(-5), Description = "Szczepienie", Price = 120 },
        new Visit { Id = 2, AnimalId = 2, Date = DateTime.Now.AddDays(-2), Description = "Badanie ogólne", Price = 80 }
    };
}