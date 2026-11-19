using System.Linq;
using WpfApp1.Models;

namespace WpfApp1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext db)
        {
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User { Role = "Администратор", Surename = "Никифорова", Name = "Весения", Stepname = "Николаевна", Login = "94d5ous@gmail.com", Password = "uzWC67" },
                    new User { Role = "Менеджер", Surename = "Степанов", Name = "Михаил", Stepname = "Артёмович", Login = "1diph5e@tutanota.com", Password = "8ntwUp" },
                    new User { Role = "Авторизированный клиент", Surename = "Михайлюк", Name = "Анна", Stepname = "Вячеславовна", Login = "5d4zbu@tutanota.com", Password = "rwVDh9" }
                );
            }

            if (!db.Products.Any())
            {
                db.Products.AddRange(
                    new Product { Article = "А112Т4", Name = "Ботинки", Price = 4990, Postav = "Kari", Proizvod = "Kari", CatTov = "Женская обувь", Sale = 3, Count = 6, Info = "Женские Ботинки демисезонные kari", Photo = "1.jpg", Eden = "шт." },
                    new Product { Article = "F635R4", Name = "Ботинки", Price = 3244, Postav = "Обувь для вас", Proizvod = "Marco Tozzi", CatTov = "Женская обувь", Sale = 2, Count = 13, Info = "Ботинки Marco Tozzi женские демисезонные", Photo = "2.jpg", Eden = "шт." }
                );
            }
            db.SaveChanges();
        }
    }
}
