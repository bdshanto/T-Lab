using TLabApp.Application.Models;

namespace TLabApp.Application.Service.IContracts;

public interface ICommonService
{
    Task<ICollection<CountryDto>> GetCountryListAsync();
    Task<ICollection<CityDto>> GetCityListByCountryIdAsync(int countryId);
    Task<ICollection<SkillDto>> GetSkillListAsync();
}