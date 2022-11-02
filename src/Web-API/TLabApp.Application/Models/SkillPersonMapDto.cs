namespace TLabApp.Application.Models;

public class SkillPersonMapDto
{
    public SkillPersonMapDto()
    {
        SkillName = String.Empty;
        PersonName = String.Empty;
    }
    public int Id { get; set; }
    public int SkillId { get; set; }
    public string SkillName { get; set; }
    public int PersonId { get; set; }
    public string PersonName { get; set; }
}