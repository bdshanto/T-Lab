using TLabApp.Application.Models;

namespace TLabApp.Application.Service.IContracts;

public interface IPersonService
{
    Task<ICollection<PersonDto>> GetPersonListAsync();
    Task<bool> AddOrUpdate(PersonDto dto);
    Task<PersonDto> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}