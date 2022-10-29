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

    [HttpGet]
    public async Task<IActionResult> GetPersonList( )
    {
        return Ok(await _iService.GetPersonListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Post(PersonDto dto, CancellationToken ct)
    {
        if (!ModelState.IsValid) return Ok(false);
        return Ok(await _iService.AddOrUpdate(dto,ct));
    }
    /*[HttpGet("get-skill-list")]
    public async Task<IActionResult> GetSkillList()
    {
        return Ok(await _iService.GetSkillListAsync());
    } */
}