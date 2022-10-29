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
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPersonList()
    {
        return Ok(await _iService.GetPersonListAsync());
    }

    [HttpPost]
    [ProducesResponseType(typeof(PersonDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] PersonDto dto)
    {
        if (!ModelState.IsValid) return Ok(false);
        return Ok(await _iService.AddOrUpdate(dto));
    }

    [HttpGet("get-by-id/{id:int}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _iService.GetByIdAsync(id));
    }
    [HttpDelete("delete/{id:int}")]
    [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(int id)
    {
        if (id > 0 is false) return Ok(false);
        return Ok(await _iService.DeleteAsync(id));
    }
}