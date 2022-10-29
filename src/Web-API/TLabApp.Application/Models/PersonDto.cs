using TLabApp.Domain.Entities;

namespace TLabApp.Application.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime DoB { get; set; }

        public City City { get; set; }
        public List<SkillPersonMapDto> Cities { get; } = new();
    }
}
