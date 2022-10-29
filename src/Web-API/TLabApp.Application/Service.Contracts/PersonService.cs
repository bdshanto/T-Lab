using System.Globalization;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using TLabApp.Application.Common;
using TLabApp.Application.Models;
using TLabApp.Application.Service.IContracts;
using TLabApp.Domain.Entities;
using TLabApp.Infrastructure.Persistence;
using static System.Net.Mime.MediaTypeNames;

namespace TLabApp.Application.Service.Contracts;

public class PersonService : IPersonService
{
    private readonly AppDbContext _context;
    private readonly IMapper _iMapper;
    public PersonService(AppDbContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
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
            }).ToListAsync();
        return dataList;
    }

    public async Task<bool> AddOrUpdate(PersonDto dto)
    {
        if (dto.Id == 0) return await Add(dto);
        return await Update(dto);
    }
    public async Task<bool> Add(PersonDto dto)
    {
       
        if (dto.FileExtensionValidate()) return false;

        var model = _iMapper.Map<Person>(dto);
        await _context.AddAsync(model);

        var isAdded = await _context.SaveChangesAsync() > 0;
        if (isAdded) await SaveLocalFile(model.ResumeUrl, dto.ResumeFile);

        return isAdded;
    }



    public async Task<bool> Update(PersonDto dto)
    {
        var model = _iMapper.Map<Person>(dto);
        _context.Update(model);
        return await _context.SaveChangesAsync() > 0;
    }





    public async Task<PersonDto> GetByIdAsync(int id)
    {
        var person = await _context.People.FindAsync(id);
        return _iMapper.Map<PersonDto>(person);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = _context.Database.ExecuteSqlRaw("delete from SkillPersonMap where PersonId = '{0}'", 1) > 0;
        isDeleted = await _context.Database.ExecuteSqlRawAsync("delete from People where Id  = '{0}'", 1) > 0;

        return isDeleted;
    }


    public async Task SaveLocalFile(string filePath, IFormFile file)
    {
        await file.CopyToAsync(new FileStream(filePath, FileMode.Create));
    }

}