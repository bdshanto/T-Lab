using TLabApp.Domain.Entities;

namespace TLabApp.Infrastructure.Persistence
{
    public class AppDbContextInitializer
    {
        public static void AuditAbleSeed()
        {
            using var db = new AppDbContext();
            var countryList = new List<Country>
            {
                new()
                {
                    Name = "Bangladesh",
                    Cities =
                    {
                        new City(){Name = "Dhaka"},
                        new City(){Name = "Chattogram"},
                        new City(){Name = "Gazipur"},
                        new City(){Name = "Cumilla"},
                        new City(){Name = "Barisal"},
                        new City(){Name = "Tangail"},
                    }
                },
                new()
                {
                    Name = "India",
                    Cities =
                    {
                        new City(){Name = "Kolkata"},
                        new City(){Name = "Pune"},
                        new City(){Name = "Chenni"},
                        new City(){Name = "Delhi"},
                    }
                }
            };
            db.Countries.AddRange(countryList);

            var skillList = new List<Skill>()
            {
                new(){Name = "C#"},
                new(){Name = "c++"},
                new(){Name = "Java"},
                new(){Name = "PHP"},
                new(){Name = "SQL"},
            };
            db.Skills.AddRange(skillList);

            var isAdded = db.SaveChanges();
        }
    }
}
