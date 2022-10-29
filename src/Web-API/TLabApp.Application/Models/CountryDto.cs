namespace TLabApp.Application.Models;

public class CountryDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}public class SkillDto
{
    public int Id { get; set; }
    public string Name { get; set; }

}
public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }

}