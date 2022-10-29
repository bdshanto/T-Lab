using Microsoft.EntityFrameworkCore;
using TLabApp.Application.Common;
using TLabApp.Application.Models;
using TLabApp.Application.Service.IContracts;
using TLabApp.Infrastructure.Persistence;

namespace TLabApp.Application.Service.Contracts;

public class PersonService : IPersonService
{
    private readonly AppDbContext _context;
    public PersonService(AppDbContext context)
    {
        _context = context;
    }


    public async Task<ICollection<PersonDto>> GetPersonListAsync()
    {
        var dataList = await _context.People
            .Include(c => c.City).ThenInclude(c => c.Country)
            .Include(c => c.SkillPersonMapList).ThenInclude(c => c.Skill)
            .Select(c => new PersonDto()
            {
                Name = c.Name,
                Skills = c.SkillPersonMapList.Select(d => d.Skill.Name).CommaSeparateString(),
                CityId = c.CityId,
                CityName = c.Name,
                CountryId = c.City.CountryId,
                CountryName = c.City.Country.Name,
                ResumeUrl = c.ResumeUrl,
                DoB = c.DoB
            })
            .ToListAsync();
        return dataList;
    }
}