using TLabApp.Domain.Common;

namespace TLabApp.Domain.Entities;

public sealed class Country : AuditAble
{
    public int Id { get; set; }
    public string Name { get; set; }
}