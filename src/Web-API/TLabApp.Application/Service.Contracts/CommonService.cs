using Microsoft.EntityFrameworkCore;
using TLabApp.Application.Models;
using TLabApp.Application.Service.IContracts;
using TLabApp.Infrastructure.Persistence;

namespace TLabApp.Application.Service.Contracts;

public class CommonService : ICommonService
{
    private readonly AppDbContext _context;
    public CommonService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<CountryDto>> GetCountryListAsync()
    {
        var dataList = await _context.Countries.Select(c => new CountryDto() { Id = c.Id, Name = c.Name }).ToListAsync();
        return dataList;
    }

    public async Task<ICollection<CityDto>> GetCityListByCountryIdAsync(int countryId)
    {
        var dataList = await _context.Cities
            .Where(c => c.CountryId == countryId)
            .Select(c => new CityDto() { Id = c.Id, Name = c.Name, CountryId = countryId })
            .ToListAsync();
        return dataList;
    }

    public async Task<ICollection<SkillDto>> GetSkillListAsync()
    {
        var dataList = await _context.Skills
            .Select(c => new SkillDto() { Id = c.Id, Name = c.Name, })
            .ToListAsync();
        return dataList;
    }
}