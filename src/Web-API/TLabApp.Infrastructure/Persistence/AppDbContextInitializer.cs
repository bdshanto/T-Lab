using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLabApp.Domain.Entities;

namespace TLabApp.Infrastructure.Persistence
{
    public class AppDbContextInitializer
    {
        public static async Task AuditAbleSeed()
        {
            await using var db = new AppDbContext();
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
            await db.Countries.AddRangeAsync(countryList);

            var skillList = new List<Skill>()
            {
                new(){Name = "C#"},
                new(){Name = "c++"},
                new(){Name = "Java"},
                new(){Name = "PHP"},
                new(){Name = "SQL"},
            };
            await db.Skills.AddRangeAsync(skillList);

            var isAdded = await db.SaveChangesAsync();
        }
    }
}
