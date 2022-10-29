using TLabApp.Domain.Common;

namespace TLabApp.Domain.Entities;

public sealed class SkillPersonMap : AuditAble
{
    public int Id { get; set; }
    public int SkillId { get; set; }
    public int PersonId { get; set; }

    public Skill Skill { get; set; }
    public Person Person { get; set; }
}