using Microsoft.AspNetCore.Mvc;
using TLabApp.Application.Models;
using TLabApp.Application.Service.IContracts;
using TLabApp.WebApi.Controllers.AppBaseControllers;

namespace TLabApp.WebApi.Controllers;

public class PersonController : AppBaseController
{
    private readonly IPersonService _iService;
    public PersonController(IPersonService iService)
    {
        _iService = iService;
    }

    [HttpGet("get-person-list")]
    public async Task<IActionResult> GetPersonList()
    {
        return Ok(await _iService.GetPersonListAsync());
    }

    /*[HttpGet("get-city-list-By-country-id")]
    public async Task<IActionResult> GetCityListByCountryId(int countryId)
    {
        if (countryId > 0 is false) return Ok(new List<CityDto>());
        return Ok(await _iService.GetCityListByCountryIdAsync(countryId));
    }
    [HttpGet("get-skill-list")]
    public async Task<IActionResult> GetSkillList()
    {
        return Ok(await _iService.GetSkillListAsync());
    }*/
}