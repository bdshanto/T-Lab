using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using TLabApp.Application.Common;
using TLabApp.Application.Models;
using TLabApp.Application.Service.IContracts;
using TLabApp.Domain.Entities;
using TLabApp.Infrastructure.Persistence;

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

        if (dto.CheckFileExtensionValidate()) return false;

        var model = _iMapper.Map<Person>(dto);
        await _context.AddAsync(model);

        var isAdded = await _context.SaveChangesAsync() > 0;
        if (isAdded) await SaveLocalFile(model.ResumeUrl, dto.ResumeFile);

        return isAdded;
    }



    public async Task<bool> Update(PersonDto dto)
    {
        var model = _iMapper.Map<Person>(dto);
        var skillMapped = await _context.SkillPersonMap.AsNoTracking().Where(c => c.PersonId == dto.Id).ToListAsync();

        var addAble = new List<SkillPersonMap>();
        var removeAble = new List<SkillPersonMap>();


        addAble.AddRange(dto.SkillPersonMapList.Where(c => c.Id == 0).Select(c => _iMapper.Map<SkillPersonMap>(c)));
        var addedIds = dto.SkillPersonMapList.Where(c => c.Id > 0).Select(c => c.Id).ToList();
        removeAble.AddRange(skillMapped.Where(c => !addedIds.Contains(c.Id)));

        _context.People.Update(model);
        _context.SkillPersonMap.RemoveRange(removeAble);
        await _context.SkillPersonMap.AddRangeAsync(addAble);

        var isUpdated = await _context.SaveChangesAsync() > 0;
        return isUpdated;

    }

    public async Task<PersonDto> GetByIdAsync(int id)
    {
        var person = await _context.People
            .Include(c => c.City)
            .Select(c => new PersonDto()
            {
                Id = c.Id,
                Name = c.Name,
                CityId = c.CityId,
                CountryId = c.City.CountryId,
                ResumeUrl = c.ResumeUrl,
                SkillPersonMapList = _iMapper.Map<List<SkillPersonMapDto>>(c.SkillPersonMapList),
                DoB = c.DoB,
            }).FirstOrDefaultAsync(c => c.Id == id);

        return person;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isDeleted = _context.Database.ExecuteSqlRaw(string.Format("DELETE FROM SkillPersonMap WHERE PersonId = '{0}'", id)) > 0;
        isDeleted = await _context.Database.ExecuteSqlRawAsync(string.Format("DELETE FROM People WHERE Id  = '{0}'", id)) > 0;

        return isDeleted;
    }

    public async Task<FileModel> GetFileByIdAsync(FileModel file)
    {

        if (string.IsNullOrEmpty(file.FileName)) return file;
        var filePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files", file.FileName);
        if (File.Exists(filePath))
        {
            var byteArr = await File.ReadAllBytesAsync(filePath);
            string base64ImageRepresentation = Convert.ToBase64String(byteArr);
            file.Base64String = base64ImageRepresentation;
            file.GetExtension();
        }

        return file;

    }


    public async Task SaveLocalFile(string fileName, IFormFile file)
    {
        var outputDir = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Files");
        if (!Directory.Exists(outputDir)) Directory.CreateDirectory(outputDir);
        outputDir = Path.Combine(outputDir, fileName);

        await using Stream fileStream = new FileStream(outputDir, FileMode.Create);
        await file.CopyToAsync(fileStream);

    }

}