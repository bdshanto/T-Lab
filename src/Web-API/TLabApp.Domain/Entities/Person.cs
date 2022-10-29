using TLabApp.Domain.Common;

namespace TLabApp.Domain.Entities;

public sealed class Person : AuditAble
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CityId { get; set; }
    public string ResumeUrl { get; set; }
    public DateTime DoB { get; set; }

    public City City { get; set; }
    public List<SkillPersonMap> SkillPersonMapList { get; } = new();
}