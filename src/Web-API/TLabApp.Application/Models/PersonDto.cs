using System.Security.AccessControl;
using TLabApp.Domain.Entities;

namespace TLabApp.Application.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        public string ResumeUrl { get; set; }
        public DateTime DoB { get; set; }
        public string Skills { get; set; }
        public List<SkillPersonMapDto> SkillPersonMapList { get; } = new();
    }
}
