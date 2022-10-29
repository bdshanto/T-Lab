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
                Id = c.Id,
                Name = c.Name,
                Skills = c.SkillPersonMapList.Select(d => d.Skill.Name).CommaSeparateString(),
                CityId = c.CityId,
                CityName = c.City.Name,
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
        var skillMapped = await _context.SkillPersonMap.Where(c => c.PersonId == dto.Id).ToListAsync();

        var addAble = new List<SkillPersonMap>();
        var removeAble = new List<SkillPersonMap>();


        addAble.AddRange(dto.SkillPersonMapList.Where(c => c.Id == 0).Select(c => _iMapper.Map<SkillPersonMap>(c)));
        var addedIds = dto.SkillPersonMapList.Where(c => c.Id > 0).Select(c => c.Id).ToList();
        removeAble.AddRange(skillMapped.Where(c => !addedIds.Contains(c.Id)));

        _context.People.Update(model);
        _context.SkillPersonMap.RemoveRange(removeAble);
        await _context.SkillPersonMap.AddRangeAsync(addAble);

        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<PersonDto> GetByIdAsync(int id)
    {
        var person = await _context.People.FindAsync(id);
        return _iMapper.Map<PersonDto>(person);
    }

    public async Task<bool> DeleteAsync(int id)
    {

        var isDeleted = _context.Database.ExecuteSqlRaw(string.Format("delete from SkillPersonMap where PersonId = '{0}'", id)) > 0;
        isDeleted = await _context.Database.ExecuteSqlRawAsync(string.Format("delete from People where Id  = '{0}'", id)) > 0;

        return isDeleted;
    }


    public async Task SaveLocalFile(string fileName, IFormFile file)
    {
        var outputDir = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files");
        try
        {
            if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
            outputDir = Path.Combine(outputDir, fileName);

            await using Stream fileStream = new FileStream(outputDir, FileMode.Create);
            await file.CopyToAsync(fileStream);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

}