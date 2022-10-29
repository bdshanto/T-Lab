using TLabApp.Domain.Common;

namespace TLabApp.Domain.Entities;

public sealed class City : AuditAble
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
}