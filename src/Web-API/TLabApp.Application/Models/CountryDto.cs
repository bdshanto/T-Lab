using Microsoft.AspNetCore.Http;
using System.Security.AccessControl;
using TLabApp.Application.Common;

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

public class FileModel
{
    public FileModel()
    {
        FileName= String.Empty;
        FileExtension = String.Empty;
        Base64String = String.Empty;
    }
    public string FileName { get; set; }
    public string FileExtension { get; set; }
    public string Base64String { get; set; }
    public int Status { get; set; }


    public void GetExtension()
    {
        FileExtension = Utils.GetFileExtension(Base64String);
    }

}