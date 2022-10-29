using System.Xml;
using Microsoft.AspNetCore.Http;
using TLabApp.Application.Common;

namespace TLabApp.Application.Models
{
    public class PersonDto
    {
        private IList<String> _extensions = new List<string>() { ".doc", ".pdf" };

        public PersonDto()
        {
            Name = string.Empty;
            ResumeUrl = string.Empty;
            
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; }
        public int CountryId { get; set; }
        public string? CountryName { get; set; }

        public string ResumeUrl { get; set; }
        public IFormFile? ResumeFile { get; set; }
        public DateTime DoB { get; set; }
        public string? Skills { get; set; }
        public List<SkillPersonMapDto> SkillPersonMapList { get; } = new();

        public bool CheckFileExtensionValidate()
        {
            if(ResumeFile == null) return true;
            var extension = ResumeFile?.Name != null ? Path.GetExtension(ResumeFile?.FileName) : string.Empty;
            var isNotValid = !(extension != null && _extensions.Contains(extension.ToLower()));
            if (!isNotValid) ResumeUrl = Utils.GenerateLocalUploadPath(ResumeFile);

            return isNotValid;

        }
    }
}
