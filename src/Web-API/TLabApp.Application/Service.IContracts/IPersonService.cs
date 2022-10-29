using TLabApp.Application.Models;

namespace TLabApp.Application.Service.IContracts;

public interface IPersonService
{
    Task<ICollection<PersonDto>> GetPersonListAsync();
}